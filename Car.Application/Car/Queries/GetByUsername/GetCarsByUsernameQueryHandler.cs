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
    public class GetCarsByUsernameQueryHandler : IRequestHandler<GetCarsByUsernameQuery, CarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public GetCarsByUsernameQueryHandler(ICarRepository carRepository, IMapper mapper)
        { 
            _mapper = mapper;
            _carRepository = carRepository;
        
        }
        /*public async Task<CarDto> Handle(GetCarsByUsernameQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByUsername(request.Username);

            var dto = _mapper.Map<CarDto>(car);

            return dto;
        }*/
        public async Task<CarDto?> Handle(GetCarsByUsernameQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByUsername(request.Username);

            if (car == null)
            {
                return null; // Brak samochodu dla użytkownika
            }

            var dto = _mapper.Map<CarDto>(car);

            return dto;
        }

    }
}
