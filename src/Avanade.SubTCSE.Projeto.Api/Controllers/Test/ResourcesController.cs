using Avanade.SubTCSE.Projeto.Api.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;

namespace Avanade.SubTCSE.Projeto.Api.Controllers.Test
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IStringLocalizer<Messages> _stringLocalizer;

        public ResourcesController(IStringLocalizer<Messages> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        //?culture=pt-BR
        [HttpGet("")]
        public IActionResult ResourceTest()
        {
            return Ok(new
            {
                Text = _stringLocalizer["TestMsg"].Value,
                DateTime_Now = DateTime.Now,
                DateTime_Now_ToUniversalTime = DateTime.Now.ToUniversalTime(),
                DateTime_UtcNow = DateTime.UtcNow                
            });
        }
    }
}
