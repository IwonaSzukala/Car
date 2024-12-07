using Car.Domain.Interfaces;
using Car.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car.Infrastructure.Repositories
{
    internal class CarRepository : ICarRepository
    {
        private readonly CarDbContext _dbContext;
        public CarRepository(CarDbContext dbContext)
        {
        _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.Car car)
        {
            _dbContext.Add(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Car>> GetAll()
            => await _dbContext.Cars.ToListAsync();

        /*public async Task<Domain.Entities.Car?> GetByUsername(string username)
        => await _dbContext.Cars.Include(c => c.User).FirstAsync(c => c.User.UserName == username);*/

        public async Task<Domain.Entities.Car?> GetByUsername(string username)
        {
            return await _dbContext.Cars
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.User.UserName == username);
        }

        public Task<Domain.Entities.Car?> GetByRegistrationNumber(string registrationNumber)
            => _dbContext.Cars.FirstOrDefaultAsync(cw => cw.RegistrationNumber.ToLower() == registrationNumber.ToLower());

        public Task<Domain.Entities.Car?> GetByVIN(string vin)
            => _dbContext.Cars.FirstOrDefaultAsync(cw => cw.VIN.ToLower() == vin.ToLower());

        public async Task<Domain.Entities.Car?> GetById(int id)
            => await _dbContext.Cars.FirstOrDefaultAsync(cw => cw.Id == id);

        public Task Commit()
            => _dbContext.SaveChangesAsync();

        public async Task Delete(Domain.Entities.Car car)
        {
            _dbContext.Cars.Remove(car);
            await Commit();
        }

        public async Task<IEnumerable<Domain.Entities.Car?>> GetCarsByUserId(string userId) 
            => await _dbContext.Cars.Include(c => c.User).Where(c => c.UserId == userId).ToListAsync();
    }
}
