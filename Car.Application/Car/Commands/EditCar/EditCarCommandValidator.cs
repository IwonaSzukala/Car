using Car.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.EditCar
{
    public class EditCarCommandValidator : AbstractValidator<EditCarCommand>
    {
        public EditCarCommandValidator(ICarRepository repository)
        {
            RuleFor(c => c.CarBrand)
                .NotEmpty().WithMessage("To pole nie może być puste");

            RuleFor(c => c.CarModel)
                .NotEmpty().WithMessage("To pole nie może być puste");

            RuleFor(c => c.ProductionYear)
                .NotEmpty().WithMessage("To pole nie może być puste")
                .MinimumLength(4).WithMessage("To pole musi składać się z 4 znaków")
                .MaximumLength(4).WithMessage("To pole musi składać się z 4 znaków");

            RuleFor(c => c.RegistrationNumber)
                .NotEmpty().WithMessage("To pole nie może być puste")
                ;


            RuleFor(c => c.VIN)
                .NotEmpty().WithMessage("To pole nie może być puste")
                .MinimumLength(17).WithMessage("To pole musi składać się z 17 znaków")
                .MaximumLength(17).WithMessage("To pole musi składać się z 17 znaków")
                ;
        }
    }
}
