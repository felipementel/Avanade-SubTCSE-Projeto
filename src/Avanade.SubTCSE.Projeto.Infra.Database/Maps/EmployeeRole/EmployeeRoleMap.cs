using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Avanade.SubTCSE.Projeto.Infra.Database.Maps.EmployeeRole
{
    public static class EmployeeRoleMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole>(map =>
            {
                map.AutoMap();

                map.SetIgnoreExtraElements(true);

                map
                .MapMember(er => er.RoleName)
                .SetElementName("roleName")
                .SetSerializer(new StringSerializer(MongoDB.Bson.BsonType.String));
            });
        }
    }
}