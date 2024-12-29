using Microsoft.AspNetCore.Mvc;
using SchoolPortal.Business.Account;
using SchoolPortal.Business.Account.Model;
using SchoolPortal.Business.School.Model.Request;

namespace SchoolPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountBusiness _accountBusiness;

        public AccountController(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }
        [HttpPost("ManagerLogin")]
        public async Task<IActionResult> ManagerLogin(RequestManagerLogin requestManagerLogin)
        {
            return Ok(await _accountBusiness.ManagerLogin(requestManagerLogin));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(RequestLogin requestLogin)
        {
            return Ok(await _accountBusiness.Login(requestLogin));
        }


    }
}
