using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Car.Application.ApplicationUserFolder;
using Car.Application.Car;
using Car.Application.Car.Commands.EditCar;
using Car.Domain.Entities;

namespace Car.Application.Mappings
{
    public class CarMappingProfile : Profile
    {
        
        public CarMappingProfile(IUserContext userContext) 
        {
            var user = userContext.GetCurrentUser();

            CreateMap<CarDto, Domain.Entities.Car>();
            CreateMap<Domain.Entities.Car, CarDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id))
                .ForMember(dto => dto.IsVisible, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id));
            /*CreateMap<Domain.Entities.Car, CarDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id))
                .ForMember(dto => dto.IsVisible, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id));*/
            

            CreateMap<CarDto, EditCarCommand>();

        }
    }
}
