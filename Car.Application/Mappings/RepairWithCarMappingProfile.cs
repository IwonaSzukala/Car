using AutoMapper;
using Car.Application.ApplicationUserFolder;
using Car.Application.Car;
using Car.Application.Car.Commands.EditCar;
using Car.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Mappings
{
    public class RepairWithCarMappingProfile : Profile
    {
        public RepairWithCarMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<Domain.Entities.Repair, RepairWithCarDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id))
                .ForMember(dto => dto.IsVisible, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id))
                .ForMember(dest => dest.CarBrand, opt => opt.MapFrom(src => src.Car.CarBrand))
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Car.CarModel))
                .ForMember(dest => dest.MechanicId, opt => opt.MapFrom(src => src.MechanicId))
                .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.ReservationDate))
                .ForMember(dest => dest.Information, opt => opt.MapFrom(src => src.Information))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
                

            CreateMap<RepairWithCarDto, EditRepairCommand>();
        }
    }
}
