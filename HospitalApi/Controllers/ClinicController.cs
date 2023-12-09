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
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IMapper _mapper;

        public ClinicController(IClinicRepository clinicRepository, IMapper mapper)
        {
            _clinicRepository = clinicRepository;
            _mapper = mapper;
        }

        // GET: api/<ClinicController>
        [HttpGet]
        public IActionResult Get()
        {
            var clinics = _mapper.Map<List<ClinicDto>>(_clinicRepository.GetAll());

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(clinics);
        }

        // GET api/<ClinicController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!_clinicRepository.ClinicExists(id))
            {
                return NotFound();
            }

            var clinic = _mapper.Map<HospitalDto>(_clinicRepository.GetClinicById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(clinic);
        }

        // POST api/<ClinicController>
        [HttpPost]
        public IActionResult Post([FromBody] ClinicDto clinicCreate)
        {
            if (clinicCreate == null)
            {
                return BadRequest("Invalid data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_clinicRepository.ClinicExists(clinicCreate.Id))
            {
                return BadRequest("Clinic already exists");
            }

            var clinicMap = _mapper.Map<Clinic>(clinicCreate);

            if (!_clinicRepository.Add(clinicMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("succesfully created");
        }

        // PUT api/<ClinicController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClinicController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
