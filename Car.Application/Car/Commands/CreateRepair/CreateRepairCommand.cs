using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.CreateRepair
{
    public class CreateRepairCommand : RepairDto, IRequest
    {
    }
}
