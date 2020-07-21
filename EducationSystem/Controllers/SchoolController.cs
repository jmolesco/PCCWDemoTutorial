using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Utility.Common;
using Utility.Response;

namespace EducationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly IMapper _mapper;
        public SchoolController(ISchoolService schoolService, IMapper mapper)
        {
            _schoolService = schoolService;
            _mapper = mapper;
        }

        [HttpPost("InsertSchool")]
        public IActionResult InsertSchool([FromBody] School model)
        {
            var mappedSchool = _mapper.Map<School>(model);
            //var School = new School
            //{
            //    Name = model.Name,
            //    Age = model.Age
            //};
            _schoolService.InsertSchool(mappedSchool);
            return Ok(
                new { Status = StatusResponse.OK }
            );
        }

        [HttpPut("UpdateSchool")]
        public IActionResult UpdateSchool([FromBody] School model)
        {
            var mappedSchool = _mapper.Map<School>(model);
            _schoolService.UpdateSchool(mappedSchool);
            return Ok(
                new { Status = StatusResponse.OK }
            );
        }


        [HttpDelete("DeleteSchool")]
        public IActionResult DeleteSchool([FromQuery] int id)
        {
            _schoolService.DeleteSchool(id);
            return Ok(
                new { Status = StatusResponse.OK }
            );
        }


        [HttpGet("GetSchool")]
        public IActionResult GetSchool([FromQuery] int id)
        {
            var result = _schoolService.GetSchool(id);
            return Ok(result);
        }
        [HttpGet("GetAllSchool")]
        public IActionResult GetAllSchool([FromQuery] Pager page)
        {
            var result = _schoolService.GetAllSchool(page);
            return Ok(result);
        }

    }
}