using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SoftServeTechnicalTask.Application.Controllers
{
    [Route("/api/organization")]
    [ApiController]
    class AuthController : ControllerBase
    {

        [HttpGet("/login")]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
        }
    }
}
