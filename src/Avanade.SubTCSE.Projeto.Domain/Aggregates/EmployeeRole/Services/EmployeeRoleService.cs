using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services;
using FluentValidation;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            var validated = await _validations.ValidateAsync(employeeRole,
                options => options.IncludeRuleSets("new"));

            if (!validated.IsValid)
            {
                employeeRole.Erros = validated.Errors.Select(x => x.ErrorMessage).ToList();
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
            var validated = await _validations.ValidateAsync(employeeRole,
                options => options.IncludeRuleSets("update"));

            if (!validated.IsValid)
            {
                employeeRole.Erros = validated.Errors.Select(x => x.ErrorMessage).ToList();
                return employeeRole;            }

            var item = await _employeeRoleRepository.FindByIdAsync(id);

            if (item is not null)
            {
                var newItem = item with
                {
                    RoleName = employeeRole.RoleName,

                    Erros = employeeRole.Erros
                };

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