using MediatR;
using Ns.Application.DTOs.ProductDtos;

namespace Ns.Application.Features.Products.Requests.Commands
{
    public class CreateProductRequest:IRequest<int>
    {
        public ProductDto ProductDto { get; set; }
    }
}
