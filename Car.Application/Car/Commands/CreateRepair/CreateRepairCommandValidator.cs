using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.CreateRepair
{
    public class CreateRepairCommandValidator : AbstractValidator<CreateRepairCommand>
    {
        public CreateRepairCommandValidator()
        {
           /* RuleFor(c => c.ReservationDate)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste");

            RuleFor(c => c.Information)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste");*/

        }
    }
}
