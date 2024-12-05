//using AutoMapper;
//using Car.Application.Car;
//using Car.Domain.Entities;
//using Car.Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace Car.Application.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;
//        private readonly IMapper _mapper;
//        public UserService(IUserRepository userRepository, IMapper mapper)
//        {
//            _userRepository = userRepository;
//            _mapper = mapper;
//        }
//        public async Task Create(UserDto userDto)
//        {
//            var user = _mapper.Map<Domain.Entities.User>(userDto);
//            await _userRepository.Create(user);
//        }


//        public async Task<User> GetUserByIdAsync(int userId)
//        {
//            return await _userRepository.FindById(userId);
//        }

//        public async Task<IEnumerable<UserDto>> GetAll()
//        {
//            var users = await _userRepository.GetAll();

//            var dtos = _mapper.Map<IEnumerable<UserDto>>(users);

//            return dtos;
//        }


//    }
//}
