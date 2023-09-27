using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses;
using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Requests;
using CloudSuite.Modules.Application.Validations.Core.RoboEmail;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails
{
  public class CheckRoboEmailExistsBySubjectHandlers : IRequestHandler<CheckRoboEmailExistsBySubjectRequest, CheckRoboEmailExistsBySubjectResponse>
  {
    private IRoboEmailRepository _roboEmailRepository;
    private readonly ILogger<CheckRoboEmailExistsBySubjectHandlers> _logger;
    public CheckRoboEmailExistsBySubjectHandlers(IRoboEmailRepository roboEmailRepository, ILogger<CheckRoboEmailExistsBySubjectHandlers> logger)
    {
      _roboEmailRepository = roboEmailRepository;
      _logger = logger;
    }

    public async Task<CheckRoboEmailExistsBySubjectResponse> Handle(CheckRoboEmailExistsBySubjectRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckRoboEmailExistsBySubjectRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckRoboEmailExistsBySubjectRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var email = await _roboEmailRepository.GetBySubject(request.Subject);

          if (email != null)
            return await Task.FromResult(new CheckRoboEmailExistsBySubjectResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckRoboEmailExistsBySubjectResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckRoboEmailExistsBySubjectResponse(request.Id, false, validationResult));
    }
  }
}