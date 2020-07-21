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
    public class SchoolStudentController : ControllerBase
    {
        private readonly ISchoolStudentService _studentSchoolService;
        private readonly IMapper _mapper;
        public SchoolStudentController(ISchoolStudentService studentSchoolService, IMapper mapper)
        {
            _studentSchoolService = studentSchoolService;
            _mapper = mapper;
        }

        [HttpPost("InsertSchoolStudent")]
        public IActionResult InsertSchoolStudent([FromBody] SchoolStudent model)
        {
            var mappedSchool = _mapper.Map<SchoolStudent>(model);
            //var School = new School
            //{
            //    Name = model.Name,
            //    Age = model.Age
            //};
            _studentSchoolService.InsertSchoolStudent(mappedSchool);
            return Ok(
                new { Status = StatusResponse.OK }
            );
        }

        [HttpPut("UpdateSchoolStudent")]
        public IActionResult UpdateSchoolStudent([FromBody] SchoolStudent model)
        {
            var mappedSchool = _mapper.Map<SchoolStudent>(model);
            _studentSchoolService.UpdateSchoolStudent(mappedSchool);
            return Ok(
                new { Status = StatusResponse.OK }
            );
        }


        [HttpDelete("DeleteSchoolStudent")]
        public IActionResult DeleteSchoolStudent([FromQuery] int id)
        {
            _studentSchoolService.DeleteSchoolStudent(id);
            return Ok(
                new { Status = StatusResponse.OK }
            );
        }


        [HttpGet("GetSchoolStudent")]
        public IActionResult GetSchoolStudent([FromQuery] int id)
        {
            var result = _studentSchoolService.GetSchoolStudent(id);
            return Ok(result);
        }
        [HttpGet("GetAllSchoolStudent")]
        public IActionResult GetAllSchoolStudent([FromQuery] Pager page)
        {
            var result = _studentSchoolService.GetAllSchoolStudent(page);
            return Ok(result);
        }
    }
}