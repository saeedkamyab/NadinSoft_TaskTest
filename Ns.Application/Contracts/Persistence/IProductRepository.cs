using Ns.Application.Contracts.Persistence.Common;
using Ns.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Ns.Application.Contracts.Persistence
{
    public interface IProductRepository:IBaseRepository<Product>
    {
       Task ChangeAvailableStatus(Product product,bool? availableStatus);
        Task<bool> IsProduceDateExist(DateTime pDate);
        Task<bool> IsEmailExist(string mEmail);
    }
}
