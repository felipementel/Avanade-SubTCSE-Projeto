using Avanade.SubTCSE.Projeto.Infra.Database.Maps.Base;

namespace Avanade.SubTCSE.Projeto.Infra.Database.Maps.Setup
{
    public static class SetupMap
    {
        public static void ConfigureMaps()
        {
            BaseEntityMap.Configure();
            EmployeeRole.EmployeeRoleMap.Configure();
            Employee.EmployeeMap.Configure();
        }
    }
}