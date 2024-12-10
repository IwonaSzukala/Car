using AutoMapper;
using Car.Application.Car.Queries.GetById;
using Car.Application.Car.Queries.GetCarsByUserId;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetRepairByUserId
{
    public class GetRepairByUserIdQueryHandler : IRequestHandler<GetRepairByUserIdQuery, IEnumerable<RepairWithCarDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepairRepository _repairRepository;

        public GetRepairByUserIdQueryHandler(IRepairRepository repairRepository, IMapper mapper)
        {

            _mapper = mapper;
            _repairRepository = repairRepository;
        }

        public async Task<IEnumerable<RepairWithCarDto>> Handle(GetRepairByUserIdQuery request, CancellationToken cancellationToken)
        {
            var repairs = await _repairRepository.GetRepairByUserId(request.UserId);
            var dto = _mapper.Map<IEnumerable<RepairWithCarDto>>(repairs);
            return dto;
        }
    }
}
