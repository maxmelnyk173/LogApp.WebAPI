using LogApp.Data;
using LogApp.Infrastructure.Models;
using LogApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<string>>> GetRoles()
        {
            return Ok(await _roleManager.Roles.Select(n => n.Name).ToListAsync());
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<UserViewModel>>> GetUsers()
        {
            var result = await _userManager.Users
                                           .Where(i => i.Role != "SuperAdmin")
                                           .Select(u => new UserViewModel
                                           {
                                                Id = u.Id,
                                                FirstName = u.FirstName,
                                                LastName = u.LastName,
                                                Email = u.Email,
                                                Role = u.Role,
                                                Position = u.Position
                                           }).ToListAsync();
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserViewModel model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser == null)
            {
                var existingRole = await _roleManager.FindByNameAsync(model.Role);

                if (existingRole == null)
                {
                    return BadRequest("Incorrect Role");
                }

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = model.Role,
                    Position = model.Position
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, user.Role);

                    return Created("", model);
                }

                return BadRequest(result.Errors);
            }

            return BadRequest("A user with this email address already exists");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (passwordCheck.Succeeded)
                {
                    var token = await CreateToken(user);

                    return Ok(new LoginnedUserViewModel
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        ExpireAt = token.ValidTo,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Position = user.Position 
                    });
                }
            }

            return Unauthorized();
        }

        [Authorize]
        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken(RefreshTokenViewModel body)
        {
            var user = await _userManager.FindByEmailAsync(body.Email);

            var token = await CreateToken(user);

            return Ok(new LoginnedUserViewModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireAt = token.ValidTo,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Position = user.Position
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser (string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("changepassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound();
            }

            var chechedPassword = await _userManager.CheckPasswordAsync(user, model.OldPassword);

            if (!chechedPassword)
            {
                return BadRequest("Wrong Password");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("changerole")]
        public async Task<ActionResult> ChangeRole (UserViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.RemoveFromRoleAsync(user, user.Role);

            var role = await _roleManager.FindByNameAsync(model.Role);

            if (role == null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(user, model.Role);

            user.Role = model.Role;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        private async Task<JwtSecurityToken> CreateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                        _config["Tokens:Issuer"],
                        _config["Tokens:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: credentials);

            return token;
        }
    }
}
