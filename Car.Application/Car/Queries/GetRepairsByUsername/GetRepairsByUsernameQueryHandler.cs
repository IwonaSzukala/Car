using AutoMapper;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetByUsername
{
    public class GetRepairsByUsernameQueryHandler : IRequestHandler<GetRepairsByUsernameQuery, IEnumerable<RepairWithCarDto>>
    {
        private readonly IRepairRepository _repairRepository;
        private readonly IMapper _mapper;
        public GetRepairsByUsernameQueryHandler(IRepairRepository repairRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repairRepository = repairRepository;

        }
        public async Task<IEnumerable<RepairWithCarDto>> Handle(GetRepairsByUsernameQuery request, CancellationToken cancellationToken)
        {
            var repair = await _repairRepository.GetByUsername(request.Username);

            var dto = _mapper.Map<IEnumerable<RepairWithCarDto>>(repair);

            return dto;
        }
    }
}
