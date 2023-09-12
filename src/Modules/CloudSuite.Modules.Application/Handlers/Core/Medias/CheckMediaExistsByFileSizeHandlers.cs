using CloudSuite.Modules.Application.Handlers.Core.Medias.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using CloudSuite.Modules.Application.Validations.Core.Medias;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias
{
  public class CheckMediaExistsByFileSizeNameHandlers : IRequestHandler<CheckMediaExistsByFileSizeRequest, CheckMediaExistsByFileSizeResponse>
  {
    private IMediaRepository _mediaRepository;
    private readonly ILogger<CheckMediaExistsByFileSizeNameHandlers> _logger;
    public CheckMediaExistsByFileSizeNameHandlers(IMediaRepository mediaRepository, ILogger<CheckMediaExistsByFileSizeNameHandlers> logger)
    {
      _mediaRepository = mediaRepository;
      _logger = logger;
    }

    public async Task<CheckMediaExistsByFileSizeResponse> Handle(CheckMediaExistsByFileSizeRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckMediaExistsByFileSizeRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckMediaExistsByFileSizeRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var media = await _mediaRepository.GetByFileSize((int)request.FileSize);

          if (media != null)
            return await Task.FromResult(new CheckMediaExistsByFileSizeResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckMediaExistsByFileSizeResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckMediaExistsByFileSizeResponse(request.Id, false, validationResult));
    }
  }
}