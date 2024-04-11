using AutoMapper;
using MediatR;
using Ns.Application.Contracts.Persistence;
using Ns.Application.Exceptions;
using Ns.Application.Features.Products.Requests.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Ns.Application.Features.Products.Handlers.Commands
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public UpdateProductRequestHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var productItem = await _productRepository.Get(request.Id);

            if (productItem == null)
                throw new NotFoundException(nameof(productItem), request.Id);
            else
            {
                if (request.UpdateProductDto != null)
                {

                    _mapper.Map(request.UpdateProductDto, productItem);
                    await _productRepository.Update(productItem);

                }
                else if (request.ChangeProductAvailable != null) { }
                {

                    await _productRepository.ChangeAvailableStatus(productItem, request.ChangeProductAvailable.IsAvailable);
                }

            }

            return Unit.Value;
        }
    }
}
