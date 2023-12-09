using AutoMapper;
using HospitalApi.Dto;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using HospitalApi.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalClinicController : ControllerBase
    {

        private readonly IHospitalClinicRepository _hospitalClinicRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IClinicRepository _clinicRepository;
        private readonly IMapper _mapper;
        public HospitalClinicController(IHospitalClinicRepository hospitalClinicRepository, IMapper mapper, 
            IHospitalRepository hospitalRepository, IClinicRepository clinicRepository)
        {
            _hospitalRepository = hospitalRepository;
            _clinicRepository = clinicRepository;
            _hospitalClinicRepository = hospitalClinicRepository;
            _mapper = mapper;
        }

        // POST api/<HospitalClinicController>
        [HttpPost]
        public IActionResult Match([FromBody] HospitalClinicDto hospitalClinicCreate)
        {
            if(hospitalClinicCreate == null)
            {
                return BadRequest("Invalid match data. Please give hospital and clinic id that you wanted match");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hospitalClinic = _mapper.Map<HospitalClinic>(hospitalClinicCreate);

            hospitalClinic.Hospital = _hospitalRepository.GetHospitalById(hospitalClinicCreate.HospitalId);
            hospitalClinic.Clinic = _clinicRepository.GetClinicById(hospitalClinicCreate.ClinicId);

            if (!_hospitalClinicRepository.Add(hospitalClinic))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Match process successfully finished!");
        }

        
    }
}
