using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task Create(Domain.Entities.Car car);
        Task<IEnumerable<Domain.Entities.Car>> GetAll();
        Task<Domain.Entities.Car> GetByUsername(string username);
        Task<Domain.Entities.Car?> GetById(int id);
        Task<Domain.Entities.Car?> GetByRegistrationNumber(string registrationNumber);
        Task<Domain.Entities.Car?> GetByVIN(string vin);
        Task Commit();
    }
}
