using MediatR;

namespace Car.Application.Car.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest
    {
        public int Id { get; set; }
    }
}
