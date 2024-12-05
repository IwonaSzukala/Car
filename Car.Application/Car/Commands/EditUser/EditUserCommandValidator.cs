using Car.Application.Car.Commands.EditCar;
using Car.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.EditUser
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator(IUserRepository repository)
        {
            RuleFor(c => c.Username)
                .NotEmpty().WithMessage("To pole nie mo�e by� puste")
                .MaximumLength(25).WithMessage("To pole mo�e sk�ada� si� z maksymalnie 25 znak�w")
                .MinimumLength(3).WithMessage("To pole musi sk�ada� si� z minimalnie 3 znak�w")
            ;

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("To pole nie mo�e by� puste")
                .NotNull().WithMessage("To pole nie mo�e by� puste"); ;

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("To pole nie mo�e by� puste");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("To pole nie mo�e by� puste")
                
                ;

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("To pole nie mo�e by� puste")
                .MaximumLength(100).WithMessage("To pole mo�e sk�ada� si� z maksymalnie 100 znak�w")
                .MinimumLength(8).WithMessage("To pole musi sk�ada� si� z minimalnie 8 znak�w");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("To pole nie mo�e by� puste")
                .Matches(@"^\d{9}$").WithMessage("To pole musi sk�ada� si� z dok�adnie 9 cyfr");
            

            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("To pole nie mo�e by� puste");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("To pole nie mo�e by� puste");

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("To pole nie mo�e by� puste")
                .MinimumLength(5).WithMessage("To pole musi sk�ada� si� z 5 lub 6 znak�w")
                .MaximumLength(6).WithMessage("To pole musi sk�ada� si� z 5 lub 6 znak�w");
        }
    }
}
