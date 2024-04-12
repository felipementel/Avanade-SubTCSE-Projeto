using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (!validated.IsValid)
            {
                employee.Erros = validated.Errors.Select(x => x.ErrorMessage).ToList();
                return employee;
            }

            return await _employeeRepository.AddAsync(employee);
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<Entities.Employee> GetEmployeeAsync(string id)
        {
            return await _employeeRepository.FindByIdAsync(id);
        }

        public async Task<List<Entities.Employee>> ListEmployeeAsync()
        {
            return await _employeeRepository.FindAllAsync();
        }

        public async Task<Entities.Employee> UpdateEmployeeAsync(string id, Entities.Employee employee)
        {
            var validated = await _validations.ValidateAsync(employee, opt =>
            {
                opt.IncludeRuleSets("update");
            });

            if (!validated.IsValid)
            {
                employee.Erros = validated.Errors.Select(x => x.ErrorMessage).ToList();
                return employee;
            }

            var item = await _employeeRepository.FindByIdAsync(id);

            if (item is not null)
            {
                var newItem = item with 
                {
                    FirstName = employee.FirstName,
                    Surname = employee.Surname,
                    Active = employee.Active,
                    Birthday = employee.Birthday,
                    EmployeeRole = employee.EmployeeRole,
                    Salary = employee.Salary,

                    Erros = employee.Erros
                };

                await _employeeRepository.UpdateAsync(newItem);

                return newItem;
            }
            else
            {
                return employee;
            }
        }
    }
}