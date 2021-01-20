using MediatR;
using System;
using System.Collections.Generic;

namespace LogApp.Application.Exports.Queries.GetExportsByDatesRange
{
    public class GetExportsByDateRangeQuery : IRequest<List<ExportVm>>
    {
        public DateTime StartDate { get; set; }

        public DateTime LastDate { get; set; }
    }
}
