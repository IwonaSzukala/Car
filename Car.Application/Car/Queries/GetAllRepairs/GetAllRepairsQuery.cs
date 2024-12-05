using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetAllRepairs
{
    public class GetAllRepairsQuery : IRequest<IEnumerable<RepairWithCarDto>>
    {
    }
}
