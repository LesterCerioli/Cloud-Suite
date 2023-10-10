using CloudSuite.Modules.Cora.Application.Handlers.Extrato.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Validations.Extrato
{
    public class CheckExtractSearchByDateRequestValidation : AbstractValidator<CheckExtractSearchByDateRequest>
    {
        public CheckExtractSearchByDateRequestValidation()
        {
            /*RuleFor(command => command.AccessToken)  QUANDO CONSEGUIR ACESSO A API DO CORA DESCOMENTAR
              .NotEmpty()
              .WithMessage("O token de acesso é obrigatório");*/

            RuleFor(command => command.Start)
              .NotEmpty()
              .WithMessage("A data de início é obrigatória");

            RuleFor(command => command.Start)
              .Must(BeAValidDate)
              .WithMessage("A data de início deve ser uma data válida");

            RuleFor(command => command.End)
              .NotEmpty()
              .WithMessage("A data de fim é obrigatória");

            RuleFor(command => command.End)
              .Must(BeAValidDate)
              .WithMessage("A data de fim deve ser uma data válida");

            /* RuleFor(command => command.End)
               .Must(BeGreaterThanStart)
               .WithMessage("A data de fim deve ser maior que a data de início");*/
        }

        private bool BeAValidDate(string date)
        {
            return DateTime.TryParse(date, out DateTime dateTime);
        }

        private bool BeGreaterThanStart(CheckExtractSearchByDateRequest request)
        {
            return DateTime.Parse(request.End) > DateTime.Parse(request.Start);
        }
    }
}

