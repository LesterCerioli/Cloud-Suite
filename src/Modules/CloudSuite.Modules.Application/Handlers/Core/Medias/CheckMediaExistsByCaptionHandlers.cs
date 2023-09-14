using CloudSuite.Modules.Application.Handlers.Core.Medias.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using CloudSuite.Modules.Application.Validations.Core.Medias;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias
{
  public class CheckMediaExistsByCaptionHandlers : IRequestHandler<CheckMediaExistsByCaptionRequest, CheckMediaExistsByCaptionResponse>
  {
    private IMediaRepository _mediaRepository;
    private readonly ILogger<CheckMediaExistsByCaptionHandlers> _logger;
    public CheckMediaExistsByCaptionHandlers(IMediaRepository mediaRepository, ILogger<CheckMediaExistsByCaptionHandlers> logger)
    {
      _mediaRepository = mediaRepository;
      _logger = logger;
    }

    public async Task<CheckMediaExistsByCaptionResponse> Handle(CheckMediaExistsByCaptionRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckMediaExistsByCaptionRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckMediaExistsByCaptionRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var media = await _mediaRepository.GetByCaption(request.Caption);

          if (media != null)
            return await Task.FromResult(new CheckMediaExistsByCaptionResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckMediaExistsByCaptionResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckMediaExistsByCaptionResponse(request.Id, false, validationResult));
    }
  }
}