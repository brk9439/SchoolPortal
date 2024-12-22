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

            return Ok(_userBusiness.CreateUser(requestCreateUser));
        }
    }
}
