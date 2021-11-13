using MongoDB.Bson.Serialization;

namespace Avanade.SubTCSE.Projeto.Infra.Data.Maps.EmployeeRole
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
                .SetElementName("roleName");
            });
        }
    }
}