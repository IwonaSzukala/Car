using Car.Domain.Entities;
using Car.Domain.Interfaces;
using Car.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Car.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly CarDbContext _dbContext;
        public UserRepository(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.ApplicationUser user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ApplicationUser> FindById(string userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        }

        public async Task<IEnumerable<Domain.Entities.ApplicationUser>> GetAll()
            => await _dbContext.Users.ToListAsync();



        public Task<Domain.Entities.ApplicationUser?> GetByName(string username)
            => _dbContext.Users.FirstOrDefaultAsync(cw => cw.UserName.ToLower() == username.ToLower());

        public Task<Domain.Entities.ApplicationUser?> GetByEmail(string email)
            => _dbContext.Users.FirstOrDefaultAsync(cw => cw.Email.ToLower() == email.ToLower());

        public async Task<Domain.Entities.ApplicationUser?> GetById(string id)
            => await _dbContext.Users.FirstOrDefaultAsync(cw => cw.Id == id);

        public Task Commit()
            => _dbContext.SaveChangesAsync();
        public async Task<string> GetRoleIdByNameAsync(string roleName)
        {
            var role = await _dbContext.Set<IdentityRole>()
                                     .Where(r => r.Name == roleName)
                                     .FirstOrDefaultAsync();

            return role?.Id;
        }

        public async Task<IEnumerable<ApplicationUser?>> GetMechanics()
        {
            var mechanicRoleId = await GetRoleIdByNameAsync("Mechanic");

            // Pobierz u�ytkownik�w, kt�rzy maj� rol� "Mechanic"
            var mechanics = await _dbContext.Set<IdentityUserRole<string>>()
                .Where(ur => ur.RoleId == mechanicRoleId)
                .Join(_dbContext.Set<ApplicationUser>(),
                        ur => ur.UserId,
                        user => user.Id,
                        (ur, user) => user)
                .ToListAsync();
            return mechanics;
        }
    }
}
