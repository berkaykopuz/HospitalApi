using AutoMapper;
using HospitalApi.Dto;
using HospitalApi.Models;

namespace HospitalApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Hospital, HospitalDto>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<Clinic, ClinicDto>();
            CreateMap<HospitalClinic, HospitalClinicDto>();
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<Timing, TimingDto>();

            CreateMap<DoctorDto, Doctor>();
            CreateMap<HospitalDto, Hospital>();
            CreateMap<ClinicDto, Clinic>();
            CreateMap<HospitalClinicDto, HospitalClinic>();
            CreateMap<AppointmentDto, Appointment>();
            CreateMap<TimingDto, Timing>();
        }
    }
}
