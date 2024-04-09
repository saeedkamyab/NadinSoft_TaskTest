﻿using AutoMapper;
using MediatR;
using Ns.Application.DTOs.Product;
using Ns.Application.Features.Product.Requests.Queries;
using Ns.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ns.Application.Features.Product.Handlers.Qeries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductListRequestHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductListDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var productlist = await _productRepository.GetAll();
            return _mapper.Map<List<ProductListDto>>(productlist);
       
        }
    }
}
