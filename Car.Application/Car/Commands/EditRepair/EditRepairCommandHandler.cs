using Car.Application.Car.Commands.EditCar;
using Car.Domain.Interfaces;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car.Application.Car.Commands.EditRepair
{
    public class EditRepairCommandHandler : IRequestHandler<EditRepairCommand>
    {
        private readonly IRepairRepository _repository;
        public EditRepairCommandHandler(IRepairRepository repository)
        {

            _repository = repository;
        }
        public async Task<Unit> Handle(EditRepairCommand? request, CancellationToken cancellationToken)
        {
            var repair = await _repository.GetById(request.Id);

            repair.MechanicId = request.MechanicId;
            repair.ReservationDate = request.ReservationDate;
            repair.Information = request.Information;
            repair.Status = request.Status;
              
            await _repository.Commit();
            return Unit.Value;
        }
    }
}
