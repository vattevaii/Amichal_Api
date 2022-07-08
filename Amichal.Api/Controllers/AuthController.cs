using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amichal.Application.Services.Authentication;
using Amichal.Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Amichal.Api.Models;

namespace Amichal.Api.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
   public class AuthController : ControllerBase
   {
      private readonly IAuthenticationService _authService;
      public AuthController(IAuthenticationService authService)
      {
         _authService = authService;
      }

      [HttpPost("login")]
      public IActionResult Login(LoginRequest req)
      {
         var authResult = _authService.Login(
            req.Email,
            req.Password);

         var response = new AuthResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.Token
            );
         return Ok(response);
      }
      [HttpPost("register")]
      public IActionResult Register(RegisterRequest req)
      {
         var authResult = _authService.Register(
            req.FirstName,
            req.LastName,
            req.Email,
            req.Password,
            req.Seller);

         var response = new AuthResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.Token
            );
         return Ok(response);
      }
        [HttpGet("test")]
        [Authorize]
        public IActionResult TestResult()
        {
            return Ok(new
            {
                message = "Accepted"
            });
        }
   }
}