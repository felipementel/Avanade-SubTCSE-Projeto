using FluentValidation.Results;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates
{
    public record BaseEntity<Tid>
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public Tid Id { get; set; }

        [BsonIgnore]
        public ValidationResult ValidationResult { get; set; }
    }
}