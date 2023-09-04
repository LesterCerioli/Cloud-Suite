using CloudSuite.Modules.Domain.Models.Token;

namespace CloudSuite.Modules.Domain.Contracts.Token
{
  public interface IRequestTokenRepository
  {
    Task<RequestToken> GetByRequestId(Guid requestId);

    Task DeleteByPhone(string telefone);

    Task Add(RequestToken requestToken);

    Task Update(RequestToken requestToken);
  }
}