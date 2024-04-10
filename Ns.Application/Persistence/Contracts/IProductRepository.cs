﻿using Ns.Application.Persistence.Contracts.Common;
using Ns.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Ns.Application.Persistence.Contracts
{
    public interface IProductRepository:IBaseRepository<Product>
    {
       Task ChangeAvailableStatus(Product product,bool? availableStatus);
        Task<bool> IsProduceDateExist(DateTime pDate);
        Task<bool> IsEmailExist(string mEmail);
    }
}
