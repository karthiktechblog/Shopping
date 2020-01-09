using AutoMapper;
using KarthikTechBlog.Shopping.API.ViewModel;
using KarthikTechBlog.Shopping.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using KarthikTechBlog.Shopping.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace KarthikTechBlog.Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductService productService, IMapper mapper)
        {
            ProductService = productService;
            Mapper = mapper;
        }

        public IProductService ProductService { get; }
        public IMapper Mapper { get; }

        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(
           [FromRoute] int productId)
        {
            var product = await ProductService.GetProductAsync(productId);

            if (product == null)
                return NotFound();

            var model = Mapper.Map<ProductViewModel>(product);
            return new OkObjectResult(model);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IReadOnlyList<ProductViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await ProductService.GetProductsAsync();

            var model = Mapper.Map<IReadOnlyList<ProductViewModel>>(products);
            return new OkObjectResult(model);
        }

        [HttpPost("", Name = "CreateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct(
           [FromBody] CreateProduct product)
        {
            var entityToAdd = Mapper.Map<Product>(product);

            await ProductService.CreateProductAsync(entityToAdd);

            return Ok();
        }

        [HttpPut("", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct(
           [FromRoute] int productId, [FromBody] UpdateProduct product)
        {

            var existingProduct = await ProductService.GetProductAsync(productId);

            if (existingProduct == null)
                return NotFound();

            var entityToUpdate = Mapper.Map<Product>(product);

            await ProductService.UpdateProductAsync(entityToUpdate);

            return Ok();
        }


        [HttpDelete("", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(
          [FromRoute] int productId)
        {

            var existingProduct = await ProductService.GetProductAsync(productId);

            if (existingProduct == null)
                return NotFound();

            await ProductService.DeleteProductAsync(productId);

            return Ok();
        }

    }
}