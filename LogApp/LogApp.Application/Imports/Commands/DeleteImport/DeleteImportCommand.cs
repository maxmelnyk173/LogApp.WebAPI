using MediatR;
using System;

namespace LogApp.Application.Imports.Commands.DeleteImport
{
    public class DeleteImportCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
