using FluentValidation;
using LogApp.Application.ShipmentStatuses.Commands.UpdateShipmentStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.ShipmentStatuses.Validators
{
    public class UpdateShipmentStatusCommandValidator : AbstractValidator<UpdateShipmentStatusCommand>
    {
        public UpdateShipmentStatusCommandValidator()
        {
            RuleFor(s => s.Status.Name).NotEmpty().NotNull();
        }
    }
}
