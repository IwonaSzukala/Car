using Car.Application.Car;
using Car.Domain.Entities;
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
    internal class RepairRepository : IRepairRepository
    {
        private readonly CarDbContext _dbContext;
        public RepairRepository(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Domain.Entities.Repair>> GetAll()
            => await _dbContext.Repairs.ToListAsync();

        public async Task Create(Domain.Entities.Repair repair)
        {
            _dbContext.Repairs.Add(repair);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Repair>> GetAllWithCars()
            => await _dbContext.Repairs.Include(r => r.Car).Include(r => r.Mechanic).ToListAsync();

        public async Task<IEnumerable<Repair>> GetByUsername(string username)
        {
            var repairs = await _dbContext.Repairs
                .Include(r => r.Car)
                .ThenInclude(c => c.User)
                .Where(r => r.Car.User.UserName == username)
                .ToListAsync();
            return repairs;
        }

        public async Task<Domain.Entities.Repair?> GetById(int id)
            => await _dbContext.Repairs.FirstOrDefaultAsync(cw => cw.Id == id);

        public Task Commit()
            => _dbContext.SaveChangesAsync();
    }
}
