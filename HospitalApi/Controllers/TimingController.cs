using AutoMapper;
using HospitalApi.Dto;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimingController : ControllerBase
    {
        private readonly ITimingRepository _timingRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public TimingController(ITimingRepository timingRepository,IDoctorRepository doctorRepository, IMapper mapper)
        {
            _timingRepository = timingRepository;
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        [HttpPost("create")]
        public IActionResult Post([FromQuery] int doctorId, [FromBody] TimingDto timingCreate)
        {
            if(timingCreate == null)
            {
                return BadRequest("Invalid timing data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timingMap = _mapper.Map<Timing>(timingCreate);
            timingMap.Doctor = _doctorRepository.GetDoctorById(doctorId);

            if (!_timingRepository.Add(timingMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created!");
        }

        [HttpGet]
        public IActionResult GetByDoctorId([FromQuery] int doctorId)
        {
            var timings = _mapper.Map<List<TimingDto>>(_timingRepository.GetTimingByDoctorId(doctorId));
            return Ok(timings);
        }
    }
}
