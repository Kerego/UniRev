using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;

namespace UniRev.Factories.Abstractions
{
	public interface IUserFactory
	{
		OptionBuilder<Student> CreateStudent(string name, string password);
	}
}
