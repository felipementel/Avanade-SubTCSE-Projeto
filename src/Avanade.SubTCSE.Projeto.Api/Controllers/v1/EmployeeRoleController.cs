using Avanade.SubTCSE.Projeto.Application.Dtos.EmployeeRole;
using Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1", Deprecated = false)]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly ILogger<EmployeeRoleController> _logger;
        private readonly IEmployeeRoleAppService _employeeRoleAppService;

        public EmployeeRoleController(
            ILogger<EmployeeRoleController> logger,
            IEmployeeRoleAppService employeeRoleAppService)
        {
            _logger = logger;
            _employeeRoleAppService = employeeRoleAppService;
        }

        [HttpGet("EmployeeRole")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var item = await _employeeRoleAppService.ListEmployeeRole();

            if (!item.Any())
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpGet("EmployeeRole/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await _employeeRoleAppService.GetEmployeeRole(id);

            if (item != null)
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpPost("EmployeeRole")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Employee([FromBody] EmployeeRoleDto employeeRoleDto, ApiVersion apiVersion)
        {
            var item = await _employeeRoleAppService.AddEmployeeRole(employeeRoleDto);

            if (!item.ValidationResult.IsValid)
            {
                return BadRequest(string.Join('\n', item.ValidationResult.Errors));
            }

            return CreatedAtAction(nameof(GetById), new
            {
                apiVersion = apiVersion.ToString(),
                id = item.Identificador
            });
        }
    }
}