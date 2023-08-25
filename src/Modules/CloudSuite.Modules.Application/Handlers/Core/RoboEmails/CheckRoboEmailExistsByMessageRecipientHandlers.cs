using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses;
using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using CloudSuite.Modules.Application.Validations.Core.RoboEmail;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails
{
  public class CheckRoboEmailExistsByMessageRecipientHandlers : IRequestHandler<CheckRoboEmailExistsByMessageRecipientRequest, CheckRoboEmailExistsByMessageRecipientResponse>
  {
    private IEmailRepository _emailRepository;
    private readonly ILogger<CheckRoboEmailExistsByMessageRecipientHandlers> _logger;
    public CheckRoboEmailExistsByMessageRecipientHandlers(IEmailRepository emailRepository, ILogger<CheckRoboEmailExistsByMessageRecipientHandlers> logger)
    {
      _emailRepository = emailRepository;
      _logger = logger;
    }

    public async Task<CheckRoboEmailExistsByMessageRecipientResponse> Handle(CheckRoboEmailExistsByMessageRecipientRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckRoboEmailExistsByMessageRecipientRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckRoboEmailExistsByMessageRecipientRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var email = await _emailRepository.GetByMessageRecipient(request.MessageRecipient);

          if (email != null)
            return await Task.FromResult(new CheckRoboEmailExistsByMessageRecipientResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckRoboEmailExistsByMessageRecipientResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckRoboEmailExistsByMessageRecipientResponse(request.Id, false, validationResult));
    }
  }
}