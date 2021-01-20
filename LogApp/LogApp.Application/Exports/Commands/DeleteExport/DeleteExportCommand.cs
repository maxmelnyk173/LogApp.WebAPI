using MediatR;
using System;

namespace LogApp.Application.Exports.Commands.DeleteExport
{
    public class DeleteExportCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
