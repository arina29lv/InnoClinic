using AutoMapper;
using PatientControl.Application.DTOs;
using PatientControl.Domain.Entities;
using System.Runtime;

namespace PatientControl.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreatePatientDto, Patient>();
            CreateMap<UpdatePatientDto, Patient>();

            CreateMap<Patient, CreatePatientDto>();
            CreateMap<Patient, UpdatePatientDto>();

        }
    }
}
