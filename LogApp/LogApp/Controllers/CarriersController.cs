using LogApp.Application.Carriers.Commands.CreateCarrier;
using LogApp.Application.Carriers.Commands.DeleteCarrier;
using LogApp.Application.Carriers.Commands.UpdateCarrier;
using LogApp.Application.Carriers.Queries;
using LogApp.Application.Carriers.Queries.GetCarrierById;
using LogApp.Application.Carriers.Queries.GetCarriersList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<CarrierViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCarriersListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarrierViewModel>> Get(Guid id)
        {
            var carrier = await Mediator.Send(new GetCarrierByIdQuery { Id = id });

            if (carrier == null)
            {
                return NotFound();
            }

            return Ok(carrier);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Create(CreateCarrierCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteCarrierCommand { Id = id });

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCarrierViewModel body)
        {
            await Mediator.Send(new UpdateCarrierCommand { Id = id, Carrier = body});

            return NoContent();
        }
    }
}
