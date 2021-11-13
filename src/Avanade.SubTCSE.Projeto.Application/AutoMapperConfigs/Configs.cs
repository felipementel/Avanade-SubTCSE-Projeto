namespace Avanade.SubTCSE.Projeto.Application.AutoMapperConfigs
{
    public static class Configs
    {
        public static AutoMapper.MapperConfiguration RegisterMappings() =>
          new AutoMapper.MapperConfiguration(cfg => 
          {
              cfg.AllowNullCollections = true;

              cfg.AddProfile(new Application.AutoMapperConfigs.Profiles.Employee.EmployeeProfile());
              cfg.AddProfile(new Application.AutoMapperConfigs.Profiles.EmployeeRole.EmployeeRoleProfile());
          });
    }
}