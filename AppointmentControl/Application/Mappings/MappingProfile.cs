using AppointmentControl.Application.DTOs;
using AppointmentControl.Domain.Entities;
using AutoMapper;

namespace AppointmentControl.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();

            CreateMap<Appointment, CreateAppointmentDto>();
            CreateMap<Appointment, UpdateAppointmentDto>();
        }
    }
}
