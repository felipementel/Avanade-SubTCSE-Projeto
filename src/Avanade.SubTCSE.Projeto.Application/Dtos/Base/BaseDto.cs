using FluentValidation.Results;
using System.Collections.Generic;

namespace Avanade.SubTCSE.Projeto.Application.Dtos.Base
{
    public abstract class BaseDto
    {
        public string Identificador { get; set; }

        public DetailInfoDto ValidationResult { get; set; }
    }

    public class DetailInfoDto
    {
        public bool IsValid { get; set; }

        public List<string> Errors { get; set; }
    }
}