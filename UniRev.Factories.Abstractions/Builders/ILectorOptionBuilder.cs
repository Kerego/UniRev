using UniRev.Domain.Models;

namespace UniRev.Factories.Abstractions.Builders
{
	public interface ILectorOptionBuilder : IOptionBuilder<Lector>
	{
		ILectorOptionBuilder WithOrganization(string organization);
	}
}