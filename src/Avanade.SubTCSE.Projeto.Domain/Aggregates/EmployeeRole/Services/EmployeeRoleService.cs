using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Repository;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Services
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private readonly IValidator<Entities.EmployeeRole> _validator;

        private readonly IEmployeeRoleRepository _employeeRoleRepository;

        public EmployeeRoleService(
            IValidator<Entities.EmployeeRole> validator,
            IEmployeeRoleRepository employeeRoleRepository)
        {
            _validator = validator;
            _employeeRoleRepository = employeeRoleRepository;
        }

        public async Task<Entities.EmployeeRole> AddEmployeeRoleAsync(Entities.EmployeeRole employeeRole)
        {
            var validated = await _validator.ValidateAsync(employeeRole, opt =>
            {
                opt.IncludeRuleSets("new");
            });

            employeeRole.ValidationResult = validated;

            if (!employeeRole.ValidationResult.IsValid)
            {
                return employeeRole;
            }

            await _employeeRoleRepository.AddAsync(employeeRole);

            return employeeRole;
        }

        public async Task<List<Entities.EmployeeRole>> GetAllAsync()
        {
            return await _employeeRoleRepository.FindAllAsync();
        }

        public async Task<Entities.EmployeeRole> GetById(string Id)
        {
            return await _employeeRoleRepository.FindByIdAsync(Id);
        }
    }
}
