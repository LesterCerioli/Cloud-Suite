using CloudSuite.Modules.Application.Handlers.Core.Medias.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using CloudSuite.Modules.Application.Validations.Core.Medias;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Medias
{
  public class CheckMediaExistsByFileNameHandlers : IRequestHandler<CheckMediaExistsByFileNameRequest, CheckMediaExistsByFileNameResponse>
  {
    private IMediaRepository _mediaRepository;
    private readonly ILogger<CheckMediaExistsByFileNameHandlers> _logger;
    public CheckMediaExistsByFileNameHandlers(IMediaRepository mediaRepository, ILogger<CheckMediaExistsByFileNameHandlers> logger)
    {
      _mediaRepository = mediaRepository;
      _logger = logger;
    }

    public async Task<CheckMediaExistsByFileNameResponse> Handle(CheckMediaExistsByFileNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckMediaExistsByFileNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckMediaExistsByFileNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var media = await _mediaRepository.GetByFileName(request.FileName);

          if (media != null)
            return await Task.FromResult(new CheckMediaExistsByFileNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckMediaExistsByFileNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckMediaExistsByFileNameResponse(request.Id, false, validationResult));
    }
  }
}