using MongoDB.Bson.Serialization;

namespace Avanade.SubTCSE.Projeto.Infra.Database.Maps.Employee
{
    public static class EmployeeMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Domain.Aggregates.Employee.Entities.Employee>(map =>
            {
                map.AutoMap();

                map.SetIgnoreExtraElements(true);

                map
                .MapMember(er => er.FirstName)
                .SetElementName("firstName");
            });
        }
    }
}