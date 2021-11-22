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

        public async Task<EmployeeRole.Entities.EmployeeRole> AddEmployeeRoleAsync(EmployeeRole.Entities.EmployeeRole employeeRole)
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

            await _employeeRoleRepository.AddAsync(employeeRole);

            return employeeRole;
        }

        public async Task DeleteEmployeeRoleAsync(string id)
        {
            await _employeeRoleRepository.DeleteAsync(id);
        }

        public async Task<Entities.EmployeeRole> GetEmployeeRoleAsync(string id)
        {
            return await _employeeRoleRepository.FindByIdAsync(id);
        }

        public async Task<List<Entities.EmployeeRole>> ListEmployeeRoleAsync()
        {
            return await _employeeRoleRepository.FindAllAsync();
        }

        public async Task<Entities.EmployeeRole> UpdateEmployeeRoleAsync(string id, Entities.EmployeeRole employeeRole)
        {
            var item = await _employeeRoleRepository.FindByIdAsync(id);

            if (item is not null)
            {
                var newItem = item with { RoleName = employeeRole.RoleName };

                await _employeeRoleRepository.UpdateAsync(newItem);

                return newItem;
            }
            else
            {
                //TODO: Return Validation Result
                return employeeRole;
            }
        }
    }
}