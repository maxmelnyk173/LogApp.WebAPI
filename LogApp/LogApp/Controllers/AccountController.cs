using LogApp.Data;
using LogApp.Infrastructure.Models;
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
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration config;


        public AccountController(
            ILogger<AccountController> logger,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config)
        {
            this.logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.config = config;
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<string>>> GetRoles()
        {
            return Ok(await roleManager.Roles.Select(n => n.Name).ToListAsync());
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<UserVm>>> GetUsers()
        {
            var result = await userManager.Users
                                            .Select(u => new UserVm
                                            {
                                                Id = u.Id,
                                                FirstName = u.FirstName,
                                                LastName = u.LastName,
                                                Email = u.Email,
                                                Role = u.Role
                                            }).ToListAsync();
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserVm model)
        {
            var existingUser = await userManager.FindByEmailAsync(model.Email);

            if (existingUser == null)
            {
                var existingRole = await roleManager.FindByNameAsync(model.Role);

                if (existingRole != null)
                {
                    ApplicationUser user = new ApplicationUser();
                    user.UserName = model.Email;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Role = model.Role;

                    IdentityResult result = userManager.CreateAsync(user, model.Password).Result;

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, user.Role);

                        return Created("", model);
                    }
                }
                else
                {
                    return BadRequest("Incorrect Role");
                }
            }
            return BadRequest("A user with this email address already exists");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserVm model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var passwordCheck = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (passwordCheck.Succeeded)
                {
                    JwtSecurityToken token = await CreateToken(user);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
            }
            return Unauthorized();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser (string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("changepassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordVm model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound();
            }

            var chechedPassword = await userManager.CheckPasswordAsync(user, model.OldPassword);

            if (!chechedPassword)
            {
                return BadRequest("Wrong Password");
            }

            var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("changerole")]
        public async Task<ActionResult> ChangeRole (UserVm model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound();
            }

            await userManager.RemoveFromRoleAsync(user, user.Role);

            var role = await roleManager.FindByNameAsync(model.Role);

            if (role == null)
            {
                return NotFound();
            }

            await userManager.AddToRoleAsync(user, model.Role);

            user.Role = model.Role;

            var result = await userManager.UpdateAsync(user);

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

            var roles = await userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokens:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                config["Tokens:Issuer"],
                config["Tokens:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: credentials
                );

            return token;
        }
    }
}
