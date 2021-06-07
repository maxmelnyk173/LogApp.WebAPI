using LogApp.Application.ShipmentStatuses.Commands.CreateShipmentStatus;
using LogApp.Application.ShipmentStatuses.Commands.DeleteShipmentStatus;
using LogApp.Application.ShipmentStatuses.Commands.UpdateShipmentStatus;
using LogApp.Application.ShipmentStatuses.Queries;
using LogApp.Application.ShipmentStatuses.Queries.GetShipmentStatusById;
using LogApp.Application.ShipmentStatuses.Queries.GetShipmentStatusesList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogApp.Controllers
{
    public class ShipmentStatusesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ShipmentStatusViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetShipmentStatusesListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentStatusViewModel>> Get(Guid id)
        {
            var carrier = await Mediator.Send(new GetShipmentStatusByIdQuery { Id = id });

            if (carrier == null)
            {
                return NotFound();
            }

            return Ok(carrier);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Create(CreateShipmentStatusCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteShipmentStatusCommand { Id = id });

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateShipmentStatusViewModel body)
        {
            await Mediator.Send(new UpdateShipmentStatusCommand { Id = id, Status = body});

            return NoContent();
        }
    }
}
