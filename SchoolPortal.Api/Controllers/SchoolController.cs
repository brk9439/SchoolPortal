﻿using Microsoft.AspNetCore.Mvc;
using SchoolPortal.Business.School;
using SchoolPortal.Business.School.Model.Request;

namespace SchoolPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ISchoolBusiness _schoolBusiness;
        public SchoolController(ISchoolBusiness schoolBusiness)
        {
            _schoolBusiness = schoolBusiness;
        }

        [HttpPost("CreateSchool")]
        public async Task<IActionResult> CreateSchool(RequestCreateSchool requestCreateSchool)
        {

            return Ok(await _schoolBusiness.CreateSchool(requestCreateSchool));
        }

        [HttpGet]
        public async Task<IActionResult> GetSchoolList()
        {
            return Ok(await _schoolBusiness.GetSchoolList());
        }
        [HttpGet("SchoolInfo/{id}")]
        public async Task<IActionResult> SchoolInfo(Guid id)
        {
            return Ok(await _schoolBusiness.SchoolInfo(id));
        }

        [HttpGet("GetStudentList/{schoolId}")]
        public async Task<IActionResult> GetStudentList(Guid schoolId)
        {
            return Ok(await _schoolBusiness.GetStudentList(schoolId));
        }

    }
}
