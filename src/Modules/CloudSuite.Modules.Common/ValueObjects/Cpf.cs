using NetDevPack.Domain;

namespace CloudSuite.Modules.Common.ValueObjects
{
	public class Cpf : ValueObject
	{
		protected override IEnumerable<object> GetEqualityComponents()
		{
			throw new NotImplementedException();
		}
	}
}