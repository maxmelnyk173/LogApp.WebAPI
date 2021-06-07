using LogApp.Application.Shipments.Commands.CreateShipment;
using LogApp.Application.Shipments.Commands.DeleteShipment;
using LogApp.Application.Shipments.Commands.UpdateShipment;
using LogApp.Application.Shipments.Queries;
using LogApp.Application.Shipments.Queries.GetShipmentById;
using LogApp.Application.Shipments.Queries.GetShipmentsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ApiController
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
