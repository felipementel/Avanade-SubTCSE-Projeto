using Avanade.SubTCSE.Projeto.Domain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Base.Repository
{
    public interface IBaseRepository<TEntity, Tid> where TEntity : BaseEntity<Tid>
    {
        Task<TEntity> Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(Tid id);

        Task<TEntity> FindById(Tid id);

        Task<IEnumerable<TEntity>> FindAll();
    }
}