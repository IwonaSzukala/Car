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
//    public class RepairService : IRepairService
//    {
//        private readonly IRepairRepository _repairRepository;
//        private readonly IMapper _mapper;
//        public RepairService(IRepairRepository repairRepository, IMapper mapper)
//        {
//            _repairRepository = repairRepository;
//            _mapper = mapper;
//        }
//        public async Task Create(RepairDto repairDto)
//        {
//            var repair = _mapper.Map<Domain.Entities.Repair>(repairDto);
//            await _repairRepository.Create(repair);
//        }

//        //public async Task<User> GetUserByIdAsync(int userId)
//        //{
//        //    return await _repairRepository.FindById(userId);
//        //}

//        public async Task<IEnumerable<RepairDto>> GetAll()
//        {
//            var repairs = await _repairRepository.GetAll();

//            var dtos = _mapper.Map<IEnumerable<RepairDto>>(repairs);

//            return dtos;
//        }

//        public async Task<IEnumerable<RepairWithCarDto>> GetAllWithCars()
//        {
//            var repairsWithCars = await _repairRepository.GetAllWithCars();
//            var dtos = _mapper.Map<IEnumerable<RepairWithCarDto>>(repairsWithCars);
//            return dtos;
//        }
//    }
//}
