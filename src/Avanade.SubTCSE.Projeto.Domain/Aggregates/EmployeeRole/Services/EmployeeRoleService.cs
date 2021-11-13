using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Services
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private readonly IValidator<EmployeeRole.Entities.EmployeeRole> _validations;

        private readonly IEmployeeRoleRepository _employeeRoleRepository;

        public EmployeeRoleService(
            IValidator<Entities.EmployeeRole> validations,
            IEmployeeRoleRepository employeeRoleRepository)
        {
            _validations = validations;
            _employeeRoleRepository = employeeRoleRepository;
        }

        public async Task<EmployeeRole.Entities.EmployeeRole> AddEmployeeRole(EmployeeRole.Entities.EmployeeRole employeeRole)
        {
            if (_validations == null)
                throw new ArgumentException($"Não foi informado o validador da classe {nameof(employeeRole)}");

            var validated = await _validations.ValidateAsync(employeeRole, opt =>
            {
                opt.IncludeRuleSets("new");
            });

            employeeRole.ValidationResult = validated;

            if (!validated.IsValid)
            {
                return employeeRole;
            }

            await _employeeRoleRepository.Add(employeeRole);

            return employeeRole;
        }

        public Task<Entities.EmployeeRole> GetEmployeeRole(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entities.EmployeeRole>> ListEmployeeRole()
        {
            throw new NotImplementedException();
        }
    }
}