using Car.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Infrastructure.Seeders
{
    public class UserSeeder
    {
        private readonly CarDbContext _dbContext;
        public UserSeeder(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                /*if (!_dbContext.Users.Any())
                {
                    var janKowalski = new Domain.Entities.ApplicationUser()
                    {
                        Username = "JanKowalski",
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Email = "jankowalski2024@gmail.com",
                        Password = "haslo123",

                        ContactDetails = new()
                        {
                            City = "Kraków",
                            Street = "Szweska 2",
                            PostalCode = "30-001",
                            PhoneNumber = "+48123456789"
                        }

                    };
                    _dbContext.Users.Add(janKowalski);
                    await _dbContext.SaveChangesAsync();
                }*/
            }
        }

    }
}
