using AutoMapper;
using Car.Application.ApplicationUserFolder;
using Car.Application.Car.Commands.CreateCar;
using Car.Application.Car.Commands.CreateRepair;
using Car.Application.Car.Commands.CreateUser;
using Car.Application.Mappings;
using Car.Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext,UserContext>();

            services.AddMediatR(typeof(CreateCarCommand));
            services.AddMediatR(typeof(CreateRepairCommand));
            services.AddMediatR(typeof(CreateUserCommand));

            
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new CarMappingProfile(userContext));
                cfg.AddProfile(new RepairMappingProfile(userContext));
                cfg.AddProfile(new RepairWithCarMappingProfile(userContext));
                cfg.AddProfile(new UserMappingProfile());
            }).CreateMapper()
            );

            services.AddValidatorsFromAssemblyContaining<CreateCarCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        }
    }
}
