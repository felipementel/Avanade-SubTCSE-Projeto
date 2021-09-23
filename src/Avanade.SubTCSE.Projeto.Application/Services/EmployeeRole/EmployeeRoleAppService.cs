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

        public async Task<EmployeeRoleDto> AddEmployeeRole(EmployeeRoleDto employeeRoleDto)
        {
            var itemDomain = _mapper.Map<EmployeeRoleDto, Domain.Aggregates.EmployeeRole.Entities.EmployeeRole>(employeeRoleDto);

            var item = await _employeeService.AddEmployeeRole(itemDomain);

            return _mapper.Map<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole, EmployeeRoleDto>(item);
        }

        public Task<EmployeeRoleDto> GetEmployeeRole(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<EmployeeRoleDto>> ListEmployeeRole()
        {
            throw new System.NotImplementedException();
        }
    }
}