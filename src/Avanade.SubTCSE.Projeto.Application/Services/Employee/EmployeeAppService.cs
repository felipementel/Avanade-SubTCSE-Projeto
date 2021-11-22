using AutoMapper;
using Avanade.SubTCSE.Projeto.Application.Dtos.Employee;
using Avanade.SubTCSE.Projeto.Application.Interfaces.Employee;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Services.Employee
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IMapper _mapper;

        private readonly IEmployeeService _employeeService;

        public EmployeeAppService(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<EmployeeDto> AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var itemDomain = _mapper.Map<EmployeeDto, Domain.Aggregates.Employee.Entities.Employee>(employeeDto);

            var item = await _employeeService.AddEmployeeAsync(itemDomain);

            return _mapper.Map<Domain.Aggregates.Employee.Entities.Employee, EmployeeDto>(item);
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
        }

        public async Task<EmployeeDto> GetEmployeeAsync(string id)
        {
            var item = await _employeeService.GetEmployeeAsync(id);

            return _mapper.Map<Domain.Aggregates.Employee.Entities.Employee, EmployeeDto>(item);
        }

        public async Task<List<EmployeeDto>> ListEmployeeAsync()
        {
            var item = await _employeeService.ListEmployeeAsync();

            return _mapper.Map<List<Domain.Aggregates.Employee.Entities.Employee>, List<EmployeeDto>>(item);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(string id, EmployeeDto employeeDto)
        {
            var itemDomain = _mapper.Map<EmployeeDto, Domain.Aggregates.Employee.Entities.Employee>(employeeDto);

            var itemUpdated = await _employeeService.UpdateEmployeeAsync(id, itemDomain);

            return _mapper.Map<Domain.Aggregates.Employee.Entities.Employee, EmployeeDto>(itemUpdated);
        }
    }
}