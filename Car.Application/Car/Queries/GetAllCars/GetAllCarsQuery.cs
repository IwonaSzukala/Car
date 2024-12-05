using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetAllCars
{
    public class GetAllCarsQuery : IRequest<IEnumerable<CarDto>>
    {
        public GetAllCarsQuery()
        {
        }
    }
}
