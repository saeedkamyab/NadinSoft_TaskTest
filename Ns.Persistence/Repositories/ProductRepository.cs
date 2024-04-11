using Microsoft.EntityFrameworkCore;
using Ns.Application.Persistence.Contracts;
using Ns.Application.Persistence.Contracts.Common;
using Ns.Domain.Models;
using Ns.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        private readonly NsDbContext _context;

        public ProductRepository(NsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeAvailableStatus(Product product, bool? availableStatus)
        {
            product.IsAvailable = availableStatus.Value;

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailExist(string mEmail)
        {
            return await _context.Products.AnyAsync(p => p.ManufactureEmail == mEmail);
        }

        public async Task<bool> IsProduceDateExist(DateTime pDate)
        {
            return await _context.Products.AnyAsync(p => p.ProduceDate == pDate);
        }
    }
}
