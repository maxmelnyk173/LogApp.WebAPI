using MediatR;
using System;

namespace LogApp.Application.Exports.Queries.GetExportById
{
    public class GetExportByIdQuery : IRequest<ExportVm>
    {
        public Guid Id { get; set; }
    }
}
