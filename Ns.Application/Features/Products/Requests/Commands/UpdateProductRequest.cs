using MediatR;
using Ns.Application.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ns.Application.Features.Products.Requests.Commands
{
    public class UpdateProductRequest : IRequest<Unit>
    {
        public int Id { get; set; }

        public UpdateProductDto UpdateProductDto { get; set; }

        public ChangeProductAvailableDto ChangeProductAvailable { get; set; }
    }
}
