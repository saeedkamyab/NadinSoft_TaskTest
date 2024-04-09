using MediatR;
using Ns.Application.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ns.Application.Features.Products.Requests.Queries
{
    public class GetProductListRequest:IRequest<List<ProductListDto>>
    {

    }
}
