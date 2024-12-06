using Car.Application.ApplicationUserFolder;
using Car.Application.Car.Commands.DeleteCar;
using Car.Domain.Entities;
using Car.Domain.Interfaces;
using Car.Infrastructure.Persistence;
using Car.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("Car")));

            /*services.AddDefaultIdentity<CarDbContext>()
                .AddEntityFrameworkStores<CarDbContext>();*/
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CarDbContext>();

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepairRepository, RepairRepository>();
            services.AddScoped<IUserContext, UserContext>();

            services.AddMediatR(typeof(DeleteCarCommand));
        }
    }
}
