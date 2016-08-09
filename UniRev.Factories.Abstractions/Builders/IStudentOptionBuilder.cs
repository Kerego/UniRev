using UniRev.Domain.Models;

namespace UniRev.Factories.Abstractions.Builders
{
	public interface IStudentOptionBuilder : IOptionBuilder<Student>
	{
		IStudentOptionBuilder WithAlmaMater(string group);
	}
}
