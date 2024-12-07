using AutoMapper;
using Car.Domain.Entities;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetCarsByUserId
{

    public class GetCarsByUserIdQueryHandler : IRequestHandler<GetCarsByUserIdQuery, IEnumerable<CarDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public GetCarsByUserIdQueryHandler(ICarRepository carRepository, IMapper mapper)
        {

            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<CarDto>> Handle(GetCarsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetCarsByUserId(request.UserId);
            var dto = _mapper.Map<IEnumerable<CarDto>>(cars);
            return dto;
        }
    }



}
