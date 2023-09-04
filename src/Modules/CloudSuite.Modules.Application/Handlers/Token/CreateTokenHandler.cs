using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using CloudSuite.Modules.Application.Validations.Token;
using CloudSuite.Modules.Domain.Contracts.Token;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;
using CloudSuite.Modules.Application.Handlers.Token.Responses;

namespace CloudSuite.Modules.Application.Handlers.Token
{
  public class CreateTokenHandler : IRequestHandler<CreateTokenCommand, CreateTokenResponse>
  {
    private IRequestTokenRepository _requestTokenRepository;
    private readonly ILogger<CreateTokenHandler> _logger;
    public CreateTokenHandler(IRequestTokenRepository requestTokenRepository, ILogger<CreateTokenHandler> logger)
    {
      _requestTokenRepository = requestTokenRepository;
      _logger = logger;
    }

    public async Task<CreateTokenResponse> Handle(CreateTokenCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateTokenCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateTokenCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var address = await _addressRepository.GetByAddressLine(command.AddressLine1);

          if (address != null)
            return await Task.FromResult(new CreateAddressResponse(command.Id, "Endereço já cadastrado"));

          await _addressRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateAddressResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateAddressResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }

      return await Task.FromResult(new CreateAddressResponse(command.Id, validationResult));
    }
  }
}