using AccountControl.Application.DTOs;
using AccountControl.Domain.Entities;
using AutoMapper;

namespace AccountControl.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateAccountDto, Account>();
            CreateMap<UpdateAccountDto, Account>();

            CreateMap<Account, CreateAccountDto>();
            CreateMap<Account, UpdateAccountDto>();
        }
    }
}
