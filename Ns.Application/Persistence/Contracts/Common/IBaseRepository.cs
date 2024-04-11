using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ns.Application.Persistence.Contracts.Common
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);

        Task<IReadOnlyList<TEntity>> GetAll();

        Task<bool> IsExist(int id);

        Task<TEntity> Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

    }
}
