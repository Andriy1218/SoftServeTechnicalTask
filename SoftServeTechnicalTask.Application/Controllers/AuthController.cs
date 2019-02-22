using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Application.Controllers
{
    [Route("/api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = "/api/auth/finish_login" });
        }

        [HttpGet("finish_login")]
        public async Task<IActionResult> FinishLogin()
        {
            var nameIdentifier = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var login = User.FindFirst(c => c.Type == "urn:github:login").Value;

            var user = new User(User.Identity.Name, login, nameIdentifier);
            await _userRepository.CreateAsync(user);

            return Ok();
        }
    }

    public class HomeController : Controller
    {
        [HttpGet("/")]

        public IActionResult Main(string code)
        {
            return Ok(User.Identity.IsAuthenticated);
        }
    }
}
