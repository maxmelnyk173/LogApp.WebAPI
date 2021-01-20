using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogApp.Infrastructure.Models.Report;
using LogApp.Infrastructure.Models.Report.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ApiController
    {
        [HttpGet("StartDate={startdate}&EndDate={enddate}")]
        public async Task<ActionResult<List<ShipmentVm>>> GetReport (DateTime startDate, DateTime lastDate)
        {
            return Ok(await Mediator.Send(new GetReportByDateRangeCommand { StartDate = startDate, LastDate = lastDate }));
        }
    }
}
