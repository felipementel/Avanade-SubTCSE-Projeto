using Avanade.SubTCSE.Projeto.Application.Interfaces.Employee;
using Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole;
using Avanade.SubTCSE.Projeto.Application.Services.Employee;
using Avanade.SubTCSE.Projeto.Application.Services.EmployeeRole;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Entities;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Validators;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Entities;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Validators;
using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using Avanade.SubTCSE.Projeto.Infra.Database.Repositories.Base.MongoDB;
using Avanade.SubTCSE.Projeto.Infra.Database.Repositories.Employee;
using Avanade.SubTCSE.Projeto.Infra.Database.Repositories.EmployeeRole;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.SubTCSE.Projeto.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        public static void AddRegisterDependencyInjections(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(Application.AutoMapperConfigs.Configs));

            serviceCollection.AddSingleton<IMongoDBContext, MongoDBContext>();

            serviceCollection.AddScoped<IEmployeeRoleAppService, EmployeeRoleAppService>();

            serviceCollection.AddScoped<IEmployeeRoleService, EmployeeRoleService>();

            serviceCollection.AddTransient<IValidator<EmployeeRole>, EmployeeRoleValidator>();

            serviceCollection.AddScoped<IEmployeeRoleRepository, EmployeeRoleRepository>();

            serviceCollection.AddScoped<IEmployeeAppService, EmployeeAppService>();

            serviceCollection.AddScoped<IEmployeeService, EmployeeService>();

            serviceCollection.AddTransient<IValidator<Employee>, EmployeeValidator>();

            serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}