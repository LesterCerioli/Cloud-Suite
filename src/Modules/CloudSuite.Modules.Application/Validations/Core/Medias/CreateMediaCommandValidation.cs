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
      .WithMessage("Caption deve ser preenchida")
      .MinimumLength(3)
      .WithMessage("Caption muito curto");

      RuleFor(command => command.FileSize)
      .NotEmpty()
      .WithMessage("FileSize deve ser preenchida")
      .GreaterThan(0)
      .WithMessage("FileSize deve ser maior que zero");


      RuleFor(command => command.FileName)
      .NotEmpty()
      .WithMessage("FileName deve ser preenchida")
      .MinimumLength(3)
      .WithMessage("FileName muito curto");

      RuleFor(command => command.MediaType)
      .IsInEnum()
      .WithMessage("MediaType inválida")
      .Must(mediaType => mediaType.ToString().Length >= 3)
      .WithMessage("MediaType muito curta");
    }
  }
}