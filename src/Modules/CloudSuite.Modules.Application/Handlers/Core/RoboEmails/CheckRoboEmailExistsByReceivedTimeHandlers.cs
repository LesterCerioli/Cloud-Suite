using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses;
using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using CloudSuite.Modules.Application.Validations.Core.RoboEmail;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails
{
  public class CheckRoboEmailExistsByReceivedTimeHandlers : IRequestHandler<CheckRoboEmailExistsByReceivedTimeRequest, CheckRoboEmailExistsByReceivedTimeResponse>
  {
    private IEmailRepository _emailRepository;
    private readonly ILogger<CheckRoboEmailExistsByReceivedTimeHandlers> _logger;
    public CheckRoboEmailExistsByReceivedTimeHandlers(IEmailRepository emailRepository, ILogger<CheckRoboEmailExistsByReceivedTimeHandlers> logger)
    {
      _emailRepository = emailRepository;
      _logger = logger;
    }

    public async Task<CheckRoboEmailExistsByReceivedTimeResponse> Handle(CheckRoboEmailExistsByReceivedTimeRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckRoboEmailExistsByReceivedTimeRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckRoboEmailExistsByReceivedTimeRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var email = await _emailRepository.GetByReceivedTime(request.ReceivedTime);

          if (email != null)
          return await Task.FromResult(new CheckRoboEmailExistsByReceivedTimeResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckRoboEmailExistsByReceivedTimeResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckRoboEmailExistsByReceivedTimeResponse(request.Id, false, validationResult));
    }
  }
} 