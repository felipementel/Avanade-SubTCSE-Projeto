using Avanade.SubTCSE.Projeto.Application.AutoMapperConfigs.Profiles.Employee;
using Avanade.SubTCSE.Projeto.Application.AutoMapperConfigs.Profiles.EmployeeRole;

namespace Avanade.SubTCSE.Projeto.Application.AutoMapperConfigs.Profiles
{
    public static class Configs
    {
        public static AutoMapper.MapperConfiguration RegisterMappings() =>
            new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.AddProfile<EmployeeRoleProfile>();

                cfg.AddProfile<EmployeeProfile>();
            });
    }
}
