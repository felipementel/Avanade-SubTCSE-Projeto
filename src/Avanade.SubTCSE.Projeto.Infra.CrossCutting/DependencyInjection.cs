using Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole;
using Avanade.SubTCSE.Projeto.Application.Services.EmployeeRole;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Entities;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Repository;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Validators;
using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using Avanade.SubTCSE.Projeto.Infra.Data.Repositories.Base.MongoDB;
using Avanade.SubTCSE.Projeto.Infra.Data.Repositories.EmployeeRole;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.SubTCSE.Projeto.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        public static void AddRegisterDependenciesInjections(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Application.AutoMapperConfigs.Profiles.Configs));

            services.AddSingleton<IMongoDBContext, MongoDBContext>();

            services.AddScoped<IEmployeeRoleAppService, EmployeeRoleAppService>();

            services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();

            services.AddScoped<IEmployeeRoleRepository, EmployeeRoleRespository>();

            services.AddTransient<IValidator<EmployeeRole>, EmployeeRoleValidator>();
        }
    }
}