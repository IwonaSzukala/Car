using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetByUsername
{
    public class GetRepairsByUsernameQuery : IRequest<IEnumerable<RepairWithCarDto>>
    {
        public string Username { get; set; }
        public GetRepairsByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
