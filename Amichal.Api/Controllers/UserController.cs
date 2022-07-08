using Amichal.Application.Common.Interfaces.Services.Persistence;
using Amichal.Application.Services.Authentication;
using Amichal.Domain.Entities.UserRoles;
using Microsoft.AspNetCore.Mvc;
//using Amichal.Api.Models;

namespace Amichal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            //_authService = authService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("customer")]
        public IActionResult GetCustomers()
        {
            Customer c = new Customer()
            {
                
            };
            return Ok(_unitOfWork.Customers.GetAll());
        }

        [HttpGet("seller")]
        public IActionResult GetSeller()
        {
            return Ok(_unitOfWork.Sellers.GetAll());
        }
        [HttpGet("admin")]
        public IActionResult GetAdmin()
        {
            return Ok(_unitOfWork.Admins.GetAll());
        }

        [HttpGet]
        public IActionResult Getusers()
        {
            return Ok(_unitOfWork.Users.GetAll());
        }
        [HttpGet("groupadmin")]
        public IActionResult GetGroupAdmins()
        {
            var users = _unitOfWork.GroupAdmins.GetAll();
            users.ToList().ForEach(u => u is )
            return Ok(users);
        }

    }
}