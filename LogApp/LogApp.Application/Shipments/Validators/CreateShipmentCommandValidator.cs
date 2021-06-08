using FluentValidation;
using LogApp.Application.Shipments.Commands.CreateShipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.Shipments.Validators
{
    public class CreateShipmentCommandValidator : AbstractValidator<CreateShipmentCommand>
    {
        public CreateShipmentCommandValidator()
        {
        }
    }
}
