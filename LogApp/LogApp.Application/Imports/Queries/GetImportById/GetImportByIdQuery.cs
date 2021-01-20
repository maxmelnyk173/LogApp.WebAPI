using MediatR;
using System;

namespace LogApp.Application.Imports.Queries.GetImportById
{
    public class GetImportByIdQuery : IRequest<ImportVm>
    {
        public Guid Id { get; set; }
    }
}
