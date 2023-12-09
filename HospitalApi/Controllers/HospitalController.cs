﻿using AutoMapper;
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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IMapper _mapper;

        public HospitalController(IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var hospitals = _mapper.Map<List<HospitalDto>>(_hospitalRepository.GetAll());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(hospitals);
        }

        // GET api/<HospitalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!_hospitalRepository.HospitalExists(id))
            {
                return NotFound();
            }

            var hospital = _mapper.Map<HospitalDto>(_hospitalRepository.GetHospitalById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(hospital);

        }

        // POST api/<HospitalController>
        [HttpPost]
        public IActionResult Post([FromBody] HospitalDto hospitalCreate)
        {
            if(hospitalCreate == null)
            {
                return BadRequest("Invalid data");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_hospitalRepository.HospitalExists(hospitalCreate.Id))
            {
                return BadRequest("Hospital already exists");
            }

            var hospitalMap = _mapper.Map<Hospital>(hospitalCreate);

            if (!_hospitalRepository.Add(hospitalMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("succesfully created");

        }

        // PUT api/<HospitalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HospitalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
