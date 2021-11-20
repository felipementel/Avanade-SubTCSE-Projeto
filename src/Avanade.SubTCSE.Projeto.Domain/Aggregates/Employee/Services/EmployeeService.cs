using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IValidator<Employee.Entities.Employee> _validations;

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IValidator<Entities.Employee> validations,
            IEmployeeRepository employeeRepository)
        {
            _validations = validations;
            _employeeRepository = employeeRepository;
        }

        public async Task<Entities.Employee> AddEmployeeAsync(Entities.Employee employee)
        {
            if (_validations == null)
                throw new ArgumentException($"Não foi informado o validador da classe {nameof(employee)}");

            var validated = await _validations.ValidateAsync(employee, opt =>
            {
                opt.IncludeRuleSets("new");
            });

            employee.ValidationResult = validated;

            if (!validated.IsValid)
            {
                return employee;
            }

            return await _employeeRepository.AddAsync(employee);
        }

        public Task DeleteEmployeeRoleAsyncAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Employee> GetEmployeeAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entities.Employee>> ListEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeRoleAsync(string id, Entities.Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}