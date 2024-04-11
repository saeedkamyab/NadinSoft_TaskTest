using AutoMapper;
using MediatR;
using Ns.Application.Contracts.Persistence;
using Ns.Application.DTOs.ProductDtos;
using Ns.Application.Features.Products.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ns.Application.Features.Products.Handlers.Qeries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            var productRequest = await _productRepository.Get(request.Id);
            return _mapper.Map<ProductDto>(productRequest);
        }
    }
}
