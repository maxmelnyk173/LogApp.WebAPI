using MediatR;
using System;

namespace LogApp.Application.Businesses.Commands.DeleteBusiness
{
    public class DeleteBusinessCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
