using Avanade.SubTCSE.Projeto.Domain.Aggregates;
using Avanade.SubTCSE.Projeto.Domain.Base.Repository;
using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Infra.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity, Tid>
        : IBaseRepository<TEntity, Tid> where TEntity : BaseEntity<Tid>
    {
        public readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(IMongoDBContext context, string collectionName)
        {
            _collection = context.GetCollection<TEntity>(collection: collectionName);
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(id => id.Id, entity.Id);

            _collection.ReplaceOneAsync(filter: filter, replacement: entity);
        }

        public virtual void Delete(Tid id)
        {
            _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq(field: "_id", id));
        }

        public virtual async Task<TEntity> FindById(Tid id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(field: "_id", id);

            var item = await _collection.FindAsync(filter: filter);

            return item.FirstOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAll()
        {
            var all = await _collection.FindAsync(filter: new BsonDocument());

            return await all.ToListAsync();
        }
    }
}