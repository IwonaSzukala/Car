using AutoMapper;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetById
{
    public class GetRepairByIdQueryHandler : IRequestHandler<GetRepairByIdQuery, RepairDto>
    {
        private readonly IRepairRepository _repairRepository;
        private readonly IMapper _mapper;
        public GetRepairByIdQueryHandler(IRepairRepository repairRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repairRepository = repairRepository;

        }
        public async Task<RepairDto> Handle(GetRepairByIdQuery request, CancellationToken cancellationToken)
        {
            var repair = await _repairRepository.GetById(request.Id);

            var dto = _mapper.Map<RepairDto>(repair);

            return dto;
        }
    }
}
