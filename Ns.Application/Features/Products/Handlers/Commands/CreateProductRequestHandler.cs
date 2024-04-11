using AutoMapper;
using FluentValidation;
using MediatR;
using Ns.Application.Contracts.Persistence;
using Ns.Application.DTOs.ProductDtos.Validators;
using Ns.Application.Features.Products.Requests.Commands;
using Ns.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Ns.Application.Features.Products.Handlers.Commands
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateProductRequestHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validator=new CreateProductDtoValidator(_productRepository);
            var valResult = await validator.ValidateAsync(request.CreateProductDto);

            if (!valResult.IsValid)
                throw new ValidationException(valResult.Errors);



            var product = _mapper.Map<Product>(request.CreateProductDto);
            product=await _productRepository.Add(product);
            return product.Id;
        }
    }
}
