using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Car.Application.Car;
using Car.Application.Car.Commands.EditCar;
using Car.Domain.Entities;

namespace Car.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDto, Domain.Entities.ApplicationUser>()
                .ForMember(u => u.ContactDetails, opt => opt.MapFrom(src => new UserContactDetails()
                {
                    PhoneNumber = src.PhoneNumber,
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode

                }));
            //CreateMap<Domain.Entities.User, UserDto>();

            CreateMap<Domain.Entities.ApplicationUser, UserDto>()
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode));
            CreateMap<UserDto, EditUserCommand>()
    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
    .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode));
    


            CreateMap<UserDto, EditUserCommand>();

        }


    }
}
