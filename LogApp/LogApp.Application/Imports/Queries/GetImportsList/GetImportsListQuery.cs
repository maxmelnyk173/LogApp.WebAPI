using MediatR;
using System.Collections.Generic;

namespace LogApp.Application.Imports.Queries.GetImportsList
{
    public class GetImportsListQuery : IRequest<List<ImportVm>>
    {
    }
}
