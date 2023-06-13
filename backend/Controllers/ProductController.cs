using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Repositories.BaseRepo;
using Luxelane.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Controllers
{
    public class ProductController : BaseController<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>
    {
        protected readonly IProductService _productService;
        public ProductController(IProductService service) : base(service)
        {
            _productService = service;
        }

        [HttpGet]
        [NonAction]
        public override async Task<ActionResult<ICollection<ProductReadDto>>> GetAll([FromQuery] QueryOptions options)
        {
            return Ok(await _productService.GetAllAsync(options));
        }

        [HttpPatch("{id:int}")]
        public override async Task<ActionResult<ProductReadDto?>> Update(int id, ProductUpdateDto request)
        {
            var item = await _productService.UpdateAsync(id, request);
            return Ok(item);
        }
    }
}