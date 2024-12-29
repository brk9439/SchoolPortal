using Microsoft.AspNetCore.Mvc;
using SchoolPortal.Business.User;
using SchoolPortal.Business.User.Model.Request;

namespace SchoolPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(RequestCreateUser requestCreateUser)
        {

            return Ok(await _userBusiness.CreateUser(requestCreateUser));
        }

        [HttpPost("StudentRegister")]
        public async Task<IActionResult> StudentRegister(RequestStudentRegister requestStudentRegister)
        {
            return Ok(await _userBusiness.StudentRegister(requestStudentRegister));
        }
    }
}
