using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.EditCar
{
    public class EditCarCommandHandler : IRequestHandler<EditCarCommand>
    {
        private readonly ICarRepository _repository;
        public EditCarCommandHandler(ICarRepository repository)
        {
        
            _repository = repository;
        }
        public async Task<Unit> Handle(EditCarCommand? request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetById(request.Id);

            car.CarBrand = request.CarBrand;
            car.CarModel = request.CarModel;
            car.ProductionYear = request.ProductionYear;
            car.RegistrationNumber = request.RegistrationNumber;
            car.VIN = request.VIN;

            await _repository.Commit();
            return Unit.Value;
        }
    }
}
