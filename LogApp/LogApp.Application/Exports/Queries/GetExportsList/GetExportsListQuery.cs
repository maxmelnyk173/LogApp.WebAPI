using MediatR;
using System.Collections.Generic;

namespace LogApp.Application.Exports.Queries.GetExportsList
{
    public class GetExportsListQuery : IRequest<List<ExportVm>>
    {
    }
}
