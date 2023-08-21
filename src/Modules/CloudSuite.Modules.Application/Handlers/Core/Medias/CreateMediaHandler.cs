using CloudSuite.Modules.Application.Handlers.Core.Medias.Responses;
using CloudSuite.Modules.Application.Validations.Core.Medias;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias
{
  public class CreateMediaHandler : IRequestHandler<CreateMediaCommand, CreateMediaResponse>
  {
    private IMediaRepository _mediaRepository;
    private readonly ILogger<CreateMediaHandler> _logger;
    public CreateMediaHandler(IMediaRepository mediaRepository, ILogger<CreateMediaHandler> logger)
    {
      _mediaRepository = mediaRepository;
      _logger = logger;
    }

    public async Task<CreateMediaResponse> Handle(CreateMediaCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateMediaCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateMediaCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var medias = await _mediaRepository.GetByFileName(command.FileName);

          if (medias != null)
          return await Task.FromResult(new CreateMediaResponse(command.Id, "Media já cadastrado"));

          await _mediaRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateMediaResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateMediaResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateMediaResponse(command.Id, validationResult));
    }
  }
}