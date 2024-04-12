using FluentValidation.Results;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Avanade.SubTCSE.Projeto.Application.Dtos.Base
{
    public abstract class BaseDto
    {
        public string Identificador { get; set; }

        [JsonIgnore]
        public List<string> Errors { get; set; } = new List<string>();
    }
}