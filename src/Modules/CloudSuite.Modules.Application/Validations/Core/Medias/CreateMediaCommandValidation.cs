using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Handlers.Core.Medias;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Core.Medias
{
  public class CreateMediaCommandValidation : AbstractValidator<CreateMediaCommand>
  {
    public CreateMediaCommandValidation()        
    {
      RuleFor(command => command.Caption)
      .NotEmpty()
      .WithMessage("Caption deve ser preenchido")
      .MinimumLength(450)
      .WithMessage("Caption deve conter no máximo 450 caracteres");

      RuleFor(command => command.FileSize)
      .NotEmpty()
      .WithMessage("FileSize deve ser preenchido")
      .GreaterThan(0)
      .WithMessage("FileSize deve ser maior que zero");


      RuleFor(command => command.FileName)
      .NotEmpty()
      .WithMessage("FileName deve ser preenchido")
      .MinimumLength(450)
      .WithMessage("FileName deve conter no máximo 450 caracteres");

      RuleFor(command => command.MediaType)
      .IsInEnum()
      .WithMessage("MediaType inválida")
      .Must(mediaType => mediaType.ToString().Length >= 3)
      .WithMessage("MediaType muito curta");
    }
  }
}