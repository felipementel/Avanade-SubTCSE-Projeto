using Avanade.SubTCSE.Projeto.Domain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Base.Repository
{
    public interface IBaseRepository<TEntity, Tid> where TEntity : BaseEntity<Tid>
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Tid id);

        Task<TEntity> FindByIdAsync(Tid id);

        Task<List<TEntity>> FindAllAsync();
    }
}