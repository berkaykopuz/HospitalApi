using AutoMapper;
using HospitalApi.Dto;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using HospitalApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICitizenRepository _citizenRepository;
        private readonly IMapper _mapper;

        public AppointmentController(IDoctorRepository doctorRepository,
            IAppointmentRepository appointmentRepository,
            ICitizenRepository citizenRepository,
            IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
            _citizenRepository = citizenRepository;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Post([FromBody] AppointmentDto appointmentCreate)
        {
            if(appointmentCreate == null)
            {
                return BadRequest("invalid data!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appointment = _mapper.Map<Appointment>(appointmentCreate);
            appointment.Doctor = _doctorRepository.GetDoctorById(appointmentCreate.DoctorId);
            appointment.Citizen = _citizenRepository.GetCitizenById(appointmentCreate.CitizenId);

            if(!_appointmentRepository.Add(appointment))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Appointment has successfully created !");
        }

        [HttpPost("istaken")]
        public IActionResult IsTaken(AppointmentDto appointmentCreate)
        {
            var appointment = _mapper.Map<Appointment>(appointmentCreate);
            appointment.Doctor = _doctorRepository.GetDoctorById(appointmentCreate.DoctorId);
            appointment.Citizen = _citizenRepository.GetCitizenById(appointmentCreate.CitizenId);

            bool isTaken = _appointmentRepository.IsTaken(appointment);
            return Ok(isTaken);
        }

        [HttpGet("getbydoctorid")]
        public IActionResult GetAppointmentsByDoctorId(int id)
        {
            var appointments = _mapper.Map<List<AppointmentDto>>(_appointmentRepository.GetAppointmentsByDoctorId(id));
            if(appointments == null)
            {
                return NotFound();
            }

            return Ok(appointments);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetAppointmentsByUserId(string id)
        {
            var appointments = _appointmentRepository.GetAppointmentsByUserId(id);

            return Ok(appointments);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deletedAppointment = _appointmentRepository.GetAppointmentById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_appointmentRepository.Delete(deletedAppointment))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
