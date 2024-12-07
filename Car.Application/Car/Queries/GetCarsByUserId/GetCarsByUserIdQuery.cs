using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetCarsByUserId
{
    public class GetCarsByUserIdQuery : IRequest<IEnumerable<CarDto>>
    {
        public string UserId { get; }

        public GetCarsByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
