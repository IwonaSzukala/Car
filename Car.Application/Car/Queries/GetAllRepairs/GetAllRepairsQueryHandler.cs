using AutoMapper;
using Car.Application.Car.Queries.GetAllCars;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetAllRepairs
{
    internal class GetAllRepairsQueryHandler : IRequestHandler<GetAllRepairsQuery, IEnumerable<RepairWithCarDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepairRepository _repairRepository;
        public GetAllRepairsQueryHandler(IRepairRepository repairRepository, IMapper mapper)
        {
            _repairRepository = repairRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<RepairWithCarDto>> Handle(GetAllRepairsQuery request, CancellationToken cancellationToken)
        {
            var repairs = await _repairRepository.GetAllWithCars();

            var dtos = _mapper.Map<IEnumerable<RepairWithCarDto>>(repairs);

            return dtos;
        }
    }
}
