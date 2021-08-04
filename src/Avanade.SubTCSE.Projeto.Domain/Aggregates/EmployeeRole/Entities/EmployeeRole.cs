using MongoDB.Bson.Serialization.Attributes;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Entities
{
    public record EmployeeRole : BaseEntity<string>
    {
        [BsonConstructor]
        public EmployeeRole(string id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }

        public EmployeeRole(string roleName)
        {
            RoleName = roleName;
        }


        [BsonElement("roleName")]
        public string RoleName { get; init; }
    }
}
