using LogApp.Application.CostCenters.Queries.GetCostCenterList;
using LogApp.Application.CostCenters.Commands.CreateCostCenter;
using LogApp.Application.CostCenters.Commands.DeleteCostCenter;
using LogApp.Application.CostCenters.Commands.UpdateCostCenter;
using LogApp.Application.CostCenters.Queries;
using LogApp.Application.CostCenters.Queries.GetCostCenterById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCentersController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<CostCenterViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCostCenterListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CostCenterViewModel>> Get(Guid id)
        {
            var business = await Mediator.Send(new GetCostCenterByIdQuery { Id = id });

            if (business == null)
            {
                return NotFound();
            }

            return Ok(business);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Create(CreateCostCenterCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteCostCenterCommand { Id = id });

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCostCenterCommand command)
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
