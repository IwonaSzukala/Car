using Car.Application.Car.Commands.EditCar;
using Car.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.EditRepair
{
    public class EditRepairCommandValidator : AbstractValidator<EditRepairCommand>
    {
        public EditRepairCommandValidator()
        {
           
        }
    }
}
