using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using EducationSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Utility.Common;
using Utility.Response;

namespace EducationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpPost("InsertStudent")]
        public IActionResult InsertStudent([FromBody] StudentModel model)
        {
            var mappedStudent = _mapper.Map<Students>(model);
            //var School = new Students
            //{
            //    Name = model.Name,
            //    Age = model.Age
            //};
            _studentService.InsertStudent(mappedStudent);
            return Ok(
                new { Status = StatusResponse.OK }
            );
        }

        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] Students model)
        {
            var mappedStudent = _mapper.Map<Students>(model);
            _studentService.UpdateStudent(mappedStudent);
            return Ok(
                new { Status = StatusResponse.OK }
            );
        }


        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent([FromQuery] int id)
        {
            _studentService.DeleteStudent(id);
            return Ok(
                new { Status = StatusResponse.OK }
            );
        }


        [HttpGet("GetStudent")]
        public IActionResult GetStudent([FromQuery] int id)
        {
            var result = _studentService.GetStudent(id);
            return Ok(result);
        }
        [HttpGet("GetAllStudent")]
        public IActionResult GetAllStudent([FromQuery] Pager page)
        {
            var result = _studentService.GetAllStudent(page);
            return Ok(result);
        }

    }
}