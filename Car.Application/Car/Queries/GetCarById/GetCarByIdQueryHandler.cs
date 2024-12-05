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
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public GetCarByIdQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _mapper = mapper;
            _carRepository = carRepository;

        }
        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetById(request.Id);

            var dto = _mapper.Map<CarDto>(car);

            return dto;
        }
    }
}
