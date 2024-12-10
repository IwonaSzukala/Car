using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetRepairByUserId
{
    public class GetRepairByUserIdQuery : IRequest<IEnumerable<RepairWithCarDto>>
    {
        public string UserId { get; }

        public GetRepairByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
