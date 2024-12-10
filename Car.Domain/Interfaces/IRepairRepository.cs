using Car.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Interfaces
{
    public interface IRepairRepository
    {
        Task Create(Domain.Entities.Repair repair);
        Task<IEnumerable<Domain.Entities.Repair>> GetAll();
        Task<IEnumerable<Repair>> GetAllWithCars();
        Task<IEnumerable<Domain.Entities.Repair?>> GetByUsername(string username);
        Task<Domain.Entities.Repair?> GetById(int id);
        Task Commit();
        Task<IEnumerable<Domain.Entities.Repair?>> GetRepairByUserId(string userId);
    }
}
