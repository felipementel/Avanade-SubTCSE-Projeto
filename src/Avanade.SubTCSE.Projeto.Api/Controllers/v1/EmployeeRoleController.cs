using Asp.Versioning;
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

        [HttpGet("")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var item = await _employeeRoleAppService.ListEmployeeRoleAsync();

            if (!item.Any())
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await _employeeRoleAppService.GetEmployeeRoleAsync(id);

            if (item == null)
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpPost("")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EmployeeRole(
            [FromBody] EmployeeRoleDto employeeRoleDto)
        {
            var item = await _employeeRoleAppService.AddEmployeeRoleAsync(employeeRoleDto);

            if (item.Errors.Any())
            {
                return UnprocessableEntity(string.Join('\n', item.Errors));
            }

            return CreatedAtAction(nameof(GetById), new
            {
                apiVersion = new ApiVersion(
                        1,
                        0),
                id = item.Identificador
            }, item);
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EmployeeRole(
            string id, 
            [FromBody] EmployeeRoleDto employeeRoleDto)
        {
            var item = await _employeeRoleAppService.UpdateEmployeeRoleAsync(id, employeeRoleDto);

            if (item.Errors.Any())
            {
                return UnprocessableEntity(string.Join('\n', item.Errors));
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeRoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EmployeeRole(string id)
        {
            await _employeeRoleAppService.DeleteEmployeeRoleAsync(id);

            return NoContent();
        }
    }
}