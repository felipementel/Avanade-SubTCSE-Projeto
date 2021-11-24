using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Api.Controllers.Test
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyVaultController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public KeyVaultController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{secretKey}")]
        public IActionResult VaultTest(string secretKey)
        {
            return Ok(_configuration[$"{secretKey}"]);
        }
    }
}
