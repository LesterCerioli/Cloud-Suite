using CloudSuite.Modules.Application.Handlers.Backbone.Credentials.Responses;
using CredentialEntity = CloudSuite.Modules.Domain.Models.Backbone;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
namespace CloudSuite.Modules.Application.Handlers.Backbone.Credentials
{
    public class CreateCredentialCommand : IRequest<CreateCredentialResponse>
    {
        public CreateCredentialCommand()
        {
            Id = Guid.NewGuid();

        }

        public CredentialEntity GetEntity()
        {
            return new CredentialEntity(
                this.Id,
                this.Network,
                this.Cpf,
                this.Password,
                this.Login

            );

        }

        public Guid Id {get; private set;}

        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Cpf {get; set;}

        public string? Network {get; set;}


        
    }
}