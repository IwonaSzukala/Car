using AutoMapper;
using Car.Application.ApplicationUserFolder;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.CreateCar
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly IUserContext _userContext;

        public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper, IUserContext userContext)
        { 
            _mapper = mapper;
            _carRepository = carRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Domain.Entities.Car>(request);

            car.CreatedById = _userContext.GetCurrentUser().Id;

            await _carRepository.Create(car);

            return Unit.Value;
        }
    }
}
