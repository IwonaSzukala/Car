using Car.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task Create(Domain.Entities.ApplicationUser user);
        Task<ApplicationUser> FindById(string userId);

        Task<Domain.Entities.ApplicationUser?> GetByName(string username);
        Task<Domain.Entities.ApplicationUser?> GetByEmail(string email);
        Task<Domain.Entities.ApplicationUser?> GetById(string id);
        Task<IEnumerable<Domain.Entities.ApplicationUser>> GetAll();

        Task Commit();
    }
}
