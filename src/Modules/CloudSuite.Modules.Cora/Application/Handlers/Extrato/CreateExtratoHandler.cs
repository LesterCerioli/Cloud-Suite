using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using MediatR;
using CloudSuite.Modules.Application.Handlers.Cora.Extrato.Responses;
using CloudSuite.Modules.Cora.Validations.Extrato;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato;

namespace CloudSuite.Modules.Application.Handlers.Cora.Extrato
    {
        public class CreateExtratoHandler : IRequestHandler<CreateExtratoCommand, CreateExtratoResponse>
        {
            private readonly IExtratoRepository _extratoRepository;
            private readonly ILogger<CreateExtratoHandler> _logger;

            public CreateExtratoHandler(IExtratoRepository extratoRepository, ILogger<CreateExtratoHandler> logger)
            {
                _extratoRepository = extratoRepository;
                _logger = logger;
            }

            public async Task<CreateExtratoResponse> Handle(CreateExtratoCommand command, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"CreateExtratoCommand: {JsonSerializer.Serialize(command)}");

                var validationResult = new CreateExtratoCommandValidation().Validate(command);

                if (validationResult.IsValid)
                {
                    try
                    {
                        var extrato = await _extratoRepository.GetByStartAndEndDate(command.Start, command.End);

                        if (extrato != null)
                            return await Task.FromResult(new CreateExtratoResponse(command.Id, "Extrato já cadastrado"));

                        await _extratoRepository.Add(command.GetEntity());

                        return await Task.FromResult(new CreateExtratoResponse(command.Id, validationResult));
                    }
                    catch (Exception ex)
                    {
                        _logger.LogCritical(ex.Message);

                        return await Task.FromResult(new CreateExtratoResponse(command.Id, "Não foi possivel processar a solicitação."));
                    }
                }

                return await Task.FromResult(new CreateExtratoResponse(command.Id, validationResult));
            }
        }
    }