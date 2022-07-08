using Amichal.Application.Common.Interfaces.Services.Persistence;
using Amichal.Contracts.Product;
using Amichal.Domain.Entities;
using Amichal.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amichal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Product.GetAll());
        }
        public IActionResult AddProduct(ProductAddRequest product)
        {
            // check if logged in user is seller
            Guid userId = Guid.Parse(User.FindFirst("User").Value);
            // map to products
            Product _product = new Product()
            {
                Description = product.Description,
                Name = product.Name,
                Id = Guid.NewGuid(),
                Seller = 
            };
            _unitOfWork.Product.Add(_product);
            _unitOfWork.Save();
        }
    }
}
