using MediatR;
using Ns.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ns.Application.Features.Product.Requests.Queries
{
    public class GetProductListRequest:IRequest<List<ProductListDto>>
    {

    }
}
