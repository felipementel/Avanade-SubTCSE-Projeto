using Avanade.SubTCSE.Projeto.Domain.Aggregates;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

//docs: https://mongodb.github.io/mongo-csharp-driver/2.0/reference/bson/mapping/
namespace Avanade.SubTCSE.Projeto.Infra.Database.Maps.Base
{
    public static class BaseEntityMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BaseEntity<string>>(map =>
            {
                map.AutoMap();

                map.SetIgnoreExtraElements(true);

                map
                .MapIdProperty(i => i.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance);

                map
                .IdMemberMap
                .SetSerializer(new StringSerializer().WithRepresentation(MongoDB.Bson.BsonType.ObjectId));

                map
                .UnmapMember(v => v.ValidationResult);
            });
        }
    }
}
