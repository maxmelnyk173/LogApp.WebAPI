using FluentValidation;
using LogApp.Application.ShipmentStatuses.Commands.CreateShipmentStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.ShipmentStatuses.Validators
{
    public class CreateShipmentStatusCommandValidator : AbstractValidator<CreateShipmentStatusCommand>
    {
        public CreateShipmentStatusCommandValidator()
        {
            RuleFor(n => n.Name).NotNull().NotEmpty();
        }
    }
}
