using LogApp.Application.Exports.Commands.CreateExport;
using LogApp.Application.Exports.Commands.DeleteExport;
using LogApp.Application.Exports.Commands.UpdateExport;
using LogApp.Application.Exports.Queries;
using LogApp.Application.Exports.Queries.GetExportById;
using LogApp.Application.Exports.Queries.GetExportsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ExportVm>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetExportsListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExportVm>> Get(Guid id)
        {
            var carrier = await Mediator.Send(new GetExportByIdQuery { Id = id });

            if (carrier == null)
            {
                return NotFound();
            }

            return base.Ok(carrier);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Create(CreateExportCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateExportCommand command)
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
            await Mediator.Send(new DeleteExportCommand { Id = id });

            return NoContent();
        }
    }
}
