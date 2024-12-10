using Car.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRepository repository)
        {
            RuleFor(c => c.Username)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste")
                .MaximumLength(25).WithMessage("To pole mo¿e sk³adaæ siê z maksymalnie 25 znaków")
                .MinimumLength(3).WithMessage("To pole musi sk³adaæ siê z minimalnie 3 znaków")
            .Custom((value, context) =>
            {
                var existingUsername = repository.GetByName(value).Result;
                if (existingUsername != null)
                {
                    context.AddFailure($"Nazwa u¿ytkownika {value} jest ju¿ zajêta");
                }
            });

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste")
                .NotNull().WithMessage("To pole nie mo¿e byæ puste"); ;

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste")
                .Custom((value, context) =>
                {
                    var existingEmail = repository.GetByEmail(value).Result;
                    if (existingEmail != null)
                    {
                        context.AddFailure($"Adres e-mail {value} jest ju¿ zajêty");
                    }
                });

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste")
                .MaximumLength(100).WithMessage("To pole mo¿e sk³adaæ siê z maksymalnie 100 znaków")
                .MinimumLength(8).WithMessage("To pole musi sk³adaæ siê z minimalnie 8 znaków");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste")
                .Matches(@"^\d{9}$").WithMessage("To pole musi sk³adaæ siê z dok³adnie 9 cyfr");
            
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste");

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("To pole nie mo¿e byæ puste")
                .MinimumLength(5).WithMessage("To pole musi sk³adaæ siê z 5 lub 6 znaków")
                .MaximumLength(6).WithMessage("To pole musi sk³adaæ siê z 5 lub 6 znaków");

        }
    }
}
