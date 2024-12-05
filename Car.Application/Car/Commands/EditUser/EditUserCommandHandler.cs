/*using Car.Application.Car.Commands.EditCar;
using Car.Domain.Interfaces;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car.Application.Car.Commands.EditUser
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
    {
        private readonly IUserRepository _repository;
        public EditUserCommandHandler(IUserRepository repository)
        {

            _repository = repository;
        }
        public async Task<Unit> Handle(EditUserCommand? request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);

            user.Username = request.Username;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = request.Password;
            user.ContactDetails.PhoneNumber = request.PhoneNumber;
            user.ContactDetails.Street = request.Street;
            user.ContactDetails.City = request.City;
            user.ContactDetails.PostalCode = request.PostalCode;

            await _repository.Commit();
            return Unit.Value;
        }
    }
}
*/