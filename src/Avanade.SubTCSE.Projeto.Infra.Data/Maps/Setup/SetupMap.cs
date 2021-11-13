using Avanade.SubTCSE.Projeto.Infra.Data.Maps.Base;

namespace Avanade.SubTCSE.Projeto.Infra.Data.Maps.Setup
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