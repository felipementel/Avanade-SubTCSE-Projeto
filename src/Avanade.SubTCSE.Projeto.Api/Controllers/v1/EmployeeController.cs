using Asp.Versioning;
using Avanade.SubTCSE.Projeto.Application.Dtos.Employee;
using Avanade.SubTCSE.Projeto.Application.Interfaces.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1", Deprecated = false)]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeController(
            IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        [HttpGet("")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var item = await _employeeAppService.ListEmployeeAsync();

            if (!item.Any())
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await _employeeAppService.GetEmployeeAsync(id);

            if (item == null)
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpPost("")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Employee(
            [FromBody] EmployeeDto employeeDto)
        {
            var item = await _employeeAppService.AddEmployeeAsync(employeeDto);

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
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EmployeeRole(
            string id,
            [FromBody] EmployeeDto employeeRoleDto)
        {
            var item = await _employeeAppService.UpdateEmployeeAsync(id, employeeRoleDto);

            if (item.Errors.Any())
            {
                return UnprocessableEntity(string.Join('\n', item.Errors));
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EmployeeRole(string id)
        {
            await _employeeAppService.DeleteEmployeeAsync(id);

            return NoContent();
        }
    }
}