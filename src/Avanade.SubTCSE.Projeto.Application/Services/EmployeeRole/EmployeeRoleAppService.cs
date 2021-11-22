using AutoMapper;
using Avanade.SubTCSE.Projeto.Application.Dtos.EmployeeRole;
using Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Services.EmployeeRole
{
    public class EmployeeRoleAppService : IEmployeeRoleAppService
    {
        private readonly IMapper _mapper;

        private readonly IEmployeeRoleService _employeeService;

        public EmployeeRoleAppService(IMapper mapper, IEmployeeRoleService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<EmployeeRoleDto> AddEmployeeRoleAsync(EmployeeRoleDto employeeRoleDto)
        {
            var itemDomain = _mapper.Map<EmployeeRoleDto, Domain.Aggregates.EmployeeRole.Entities.EmployeeRole>(employeeRoleDto);

            var item = await _employeeService.AddEmployeeRoleAsync(itemDomain);

            return _mapper.Map<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole, EmployeeRoleDto>(item);
        }

        public async Task DeleteEmployeeRoleAsync(string id)
        {
            await _employeeService.DeleteEmployeeRoleAsync(id);
        }

        public async Task<EmployeeRoleDto> GetEmployeeRoleAsync(string id)
        {
            var item = await _employeeService.GetEmployeeRoleAsync(id);

            return _mapper.Map<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole, EmployeeRoleDto>(item);
        }

        public async Task<List<EmployeeRoleDto>> ListEmployeeRoleAsync()
        {
            var item = await _employeeService.ListEmployeeRoleAsync();

            return _mapper.Map<List<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole>, List<EmployeeRoleDto>>(item);
        }

        public async Task<EmployeeRoleDto> UpdateEmployeeRoleAsync(string id, EmployeeRoleDto employeeRoleDto)
        {
            var itemDomain = _mapper.Map<EmployeeRoleDto, Domain.Aggregates.EmployeeRole.Entities.EmployeeRole>(employeeRoleDto);

            var itemUpdated = await _employeeService.UpdateEmployeeRoleAsync(id, itemDomain);

            return _mapper.Map<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole, EmployeeRoleDto>(itemUpdated);
        }
    }
}