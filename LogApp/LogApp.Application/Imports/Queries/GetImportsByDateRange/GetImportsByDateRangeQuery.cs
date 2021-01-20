using MediatR;
using System;
using System.Collections.Generic;

namespace LogApp.Application.Imports.Queries.GetImportsByDateRange
{
    public class GetImportsByDateRangeQuery : IRequest<List<ImportVm>>
    {
        public DateTime StartDate { get; set; }

        public DateTime LastDate { get; set; }
    }
}
