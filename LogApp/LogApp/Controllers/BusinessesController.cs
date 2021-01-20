using LogApp.Application.Businesses.Commands.CreateBusiness;
using LogApp.Application.Businesses.Commands.DeleteBusiness;
using LogApp.Application.Businesses.Commands.UpdateBusiness;
using LogApp.Application.Businesses.Queries;
using LogApp.Application.Businesses.Queries.GetBusinessById;
using LogApp.Application.Businesses.Queries.GetBusinessesList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<BusinessVm>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetBusinessesListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessVm>> Get(Guid id)
        {
            var business = await Mediator.Send(new GetBusinessByIdQuery { Id = id });

            if (business == null)
            {
                return NotFound();
            }

            return Ok(business);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Create(CreateBusinessCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteBusinessCommand { Id = id });

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateBusinessCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
