using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ns.Application.Features.Products.Requests.Commands
{
    public class DeleteProductRequest:IRequest<Unit>
    {
        public int Id {  get; set; }
    }
}
