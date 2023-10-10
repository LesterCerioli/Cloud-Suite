using CloudSuite.Modules.Application.Handlers.Backbone.Credentials.Responses;
using CloudSuite.Modules.Application.Handlers.Backbone.Credentials;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;
namespace CloudSuite.Modules.Application.Handlers.Backbone.Credentials
{
    public class CreateCrentialHandler : IRequestHandler<CreateCredentialCommand, CreateCredentialResponse>
    {
        public CreateCrentialHandler(ICredentialRepository credentialRepository, ILogger<CreateCredentialHandler> logger)
        {
            _credentialRepository = credentialRepository;
            _logger = logger;
        }

        public async Task<CreateCredentialResponse> Handle(CreatecredentialCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateCredentialCommand: {JsonSerializer.Serialize(command)}");

        }

        
        
        
    }
}