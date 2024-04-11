using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ns.Application.DTOs.ProductDtos;
using Ns.Application.Features.Products.Requests.Commands;
using Ns.Application.Features.Products.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ns.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductListDto>>> Get()
        {
            var products = await _mediator.Send(new GetProductListRequest());
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductDetailRequest { Id = id });
            return Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductDto productDto)
        {
            var command = new CreateProductRequest { CreateProductDto = productDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateProductDto productDto)
        {
            var command = new UpdateProductRequest { Id = id, UpdateProductDto = productDto };
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductRequest { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("changeAvailable/{id}")]
        public async Task<ActionResult> ChangeAvailable(int id, [FromBody] ChangeProductAvailableDto productAvailableDto)
        {
            var command = new UpdateProductRequest { Id = id, ChangeProductAvailable = productAvailableDto };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
