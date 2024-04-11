using MediatR;
using Ns.Application.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ns.Application.Features.Products.Requests.Queries
{
    public class GetProductDetailRequest:IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
