using MediatR;
using System;
using System.Collections.Generic;

namespace LogApp.Application.Exports.Queries.GetExportsByDate
{
    public class GetExportsByDateQuery : IRequest<List<ExportVm>>
    {
        public DateTime Date { get; set; }
    }
}
