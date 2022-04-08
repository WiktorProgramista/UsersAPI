using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Application.Interfaces;

namespace UsersAPI.RestAPI.Controllers
{
    [ApiController]
    [Route("/api/Users")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService UserService)
        {
            userService = UserService;
        }
        //Endpoint
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public IActionResult Get()
        {

            return Json("xd");
            return Json(userService);
        }
    }
}