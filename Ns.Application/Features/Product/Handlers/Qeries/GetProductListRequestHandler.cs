using MediatR;
using Ns.Application.DTOs.Product;
using Ns.Application.Features.Product.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ns.Application.Features.Product.Handlers.Qeries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductListDto>>
    {
        public Task<List<ProductListDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
