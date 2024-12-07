using AutoMapper;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetUserWithMechanicRole
{
    public class GetUserWithMechanicRoleQueryHandler : IRequestHandler<GetUserWithMechanicRoleQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserWithMechanicRoleQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }
        public async Task<IEnumerable<UserDto>> Handle(GetUserWithMechanicRoleQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetMechanics();

            var dto = _mapper.Map<IEnumerable<UserDto>>(user);

            return dto;
        }
    }
}
