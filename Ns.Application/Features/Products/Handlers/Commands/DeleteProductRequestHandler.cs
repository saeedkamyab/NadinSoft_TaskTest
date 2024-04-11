using AutoMapper;
using MediatR;
using Ns.Application.Contracts.Persistence;
using Ns.Application.Exceptions;
using Ns.Application.Features.Products.Requests.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Ns.Application.Features.Products.Handlers.Commands
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest,Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
                var productItem = await _productRepository.Get(request.Id);

            if(productItem == null)
                throw new NotFoundException(nameof(productItem),request.Id);


                await _productRepository.Delete(productItem);
                return Unit.Value;
            
        }
    }
}
