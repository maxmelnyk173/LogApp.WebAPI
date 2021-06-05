using LogApp.Application.Imports.Commands.CreateImport;
using LogApp.Application.Imports.Commands.DeleteImport;
using LogApp.Application.Imports.Commands.UpdateImport;
using LogApp.Application.Imports.Queries;
using LogApp.Application.Imports.Queries.GetImportById;
using LogApp.Application.Imports.Queries.GetImportsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ShipmentViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetShipmentsListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentViewModel>> Get(Guid id)
        {
            var carrier = await Mediator.Send(new GetShipmentByIdQuery { Id = id });

            if (carrier == null)
            {
                return NotFound();
            }

            return base.Ok(carrier);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Create(CreateShipmentCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateShipmentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteShipmentCommand { Id = id });

            return NoContent();
        }
    }
}
