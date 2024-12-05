using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Car.Application.ApplicationUserFolder;
using Car.Application.Car;
using Car.Application.Car.Commands.EditCar;//komentarz
using Car.Domain.Entities;

namespace Car.Application.Mappings
{
    public class RepairMappingProfile : Profile
    {
        

        public RepairMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<RepairDto, Domain.Entities.Repair>();

            CreateMap<Domain.Entities.Repair, RepairDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id))
                .ForMember(dto => dto.IsVisible, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id));

            CreateMap<RepairDto, EditRepairCommand>();


        }
    }
}
