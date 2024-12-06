using Car.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Car.Application.Car.Commands.DeleteCar
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
    {
        private readonly ICarRepository _repository;

        public DeleteCarCommandHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetById(request.Id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {request.Id} not found.");
            }

            await _repository.Delete(car);

            return Unit.Value;
        }
    }
}
