//using AutoMapper;
//using Car.Application.Car;
//using Car.Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace Car.Application.Services
//{
//    public class CarService : ICarService
//    {
//        private readonly ICarRepository _carRepository;
//        private readonly IMapper _mapper;
//        public CarService(ICarRepository carRepository, IMapper mapper)
//        {
//            _carRepository = carRepository;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<CarDto>> GetAll()
//        {
//            var cars = await _carRepository.GetAll();

//            var dtos = _mapper.Map<IEnumerable<CarDto>>(cars);

//            return dtos; //wywalic to cale
//        }
//        public async Task Create(CarDto carDto)
//        {

//            //var car = _mapper.Map<Domain.Entities.Car>(carDto);

//            //await _carRepository.Create(car);

//        }
//    }
//}
