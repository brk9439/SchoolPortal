using Microsoft.AspNetCore.Mvc;

namespace SchoolPortal.Api.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
