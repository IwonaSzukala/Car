using MediatR;

namespace Car.Application.Car.Commands.EditCar
{
    public class EditUserCommand : UserDto, IRequest<Unit>
    {
    }
}
