using CloudSuite.Modules.Domain.Models.Token;
using CloudSuite.Modules.Domain.ValueObjects;

namespace CloudSuite.Modules.Domain.Contracts.Token
{
  public interface IRequestTokenRepository
  {
    Task<RequestToken> GetByRequestId(Guid requestId);

    Task DeleteByPhone(Telephone telephone);

    Task Add(RequestToken requestToken);

    Task Update(RequestToken requestToken);
  }
}