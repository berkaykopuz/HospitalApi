using AutoMapper;
using HospitalApi.Dto;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        
        private readonly IDoctorRepository _doctorRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorRepository doctorRepository, IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var doctors = _mapper.Map<List<DoctorDto>>(_doctorRepository.GetAll());
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var doctor = _mapper.Map<DoctorDto>(_doctorRepository.GetDoctorById(id));

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public IActionResult Post([FromQuery] int hospitalId, [FromBody] DoctorDto doctorCreate)
        {

            if (doctorCreate == null)
            {
                return BadRequest("Invalid doctor data");
            }

            //need "is doctor already exist" check right here

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doctorMap = _mapper.Map<Doctor>(doctorCreate);
            
            doctorMap.Hospital = _hospitalRepository.GetHospitalById(hospitalId);

            if(!_doctorRepository.Add(doctorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created!");
           
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
