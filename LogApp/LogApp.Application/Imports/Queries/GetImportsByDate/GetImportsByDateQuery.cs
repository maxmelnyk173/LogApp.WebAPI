using MediatR;
using System;
using System.Collections.Generic;

namespace LogApp.Application.Imports.Queries.GetImportsByDate
{
    public class GetImportsByDateQuery : IRequest<List<ImportVm>>
    {
        public DateTime Date { get; set; }
    }
}
