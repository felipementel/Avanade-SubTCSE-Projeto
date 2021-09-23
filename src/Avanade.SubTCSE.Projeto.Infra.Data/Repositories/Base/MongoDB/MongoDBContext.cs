using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Avanade.SubTCSE.Projeto.Infra.Data.Repositories.Base.MongoDB
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDBContext(IConfiguration configuration)
        {
            MongoClientSettings mongoClientSettings = MongoClientSettings.FromUrl(
                new MongoUrl(configuration.GetSection("MongoDb:ConnectionString").Value));

            mongoClientSettings.SslSettings =
                new SslSettings()
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };

            MongoClient mongoClient = new(settings: mongoClientSettings);

            _mongoDatabase = mongoClient.GetDatabase(configuration.GetSection("MongoDb:Database").Value);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string collection)
        {
            return _mongoDatabase.GetCollection<TEntity>(name: collection);
        }
    }
}
