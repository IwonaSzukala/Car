using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetByUsername
{
    public class GetCarsByUsernameQuery : IRequest<CarDto>
    {
        public string Username { get; set; }
        public GetCarsByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
