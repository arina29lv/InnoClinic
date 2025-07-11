using AutoMapper;
using StaffControl.Application.DTOs.DoctorDTOs;
using StaffControl.Application.DTOs.ReceptionistDTOs;
using StaffControl.Domain.Entities;

namespace StaffControl.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>();
            CreateMap<Doctor, CreateDoctorDto>();
            CreateMap<Doctor, UpdateDoctorDto>();

            CreateMap<CreateReceptionistDto, Receptionist>();
            CreateMap<UpdateReceptionistDto, Receptionist>();
            CreateMap<Receptionist, CreateReceptionistDto>();
            CreateMap<Receptionist, UpdateReceptionistDto>();
        }
    }
}
