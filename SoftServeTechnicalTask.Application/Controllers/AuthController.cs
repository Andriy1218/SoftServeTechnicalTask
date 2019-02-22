using System.Security.Claims;
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
            string login = User.FindFirst(c => c.Type == "urn:github:login").Value;
            if (login.Length == 0)
                return Forbid();

            int nameIdentifier = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var existingUser = _userRepository.GetByNameIdentifier(nameIdentifier);
            if (existingUser != null)
                return Ok();

            User user = new User(User.Identity.Name, login, nameIdentifier);
            await _userRepository.CreateAsync(user);
            return Ok();
        }
    }

}
