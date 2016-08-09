using UniRev.Factories.Abstractions.Builders;

namespace UniRev.Factories.Abstractions
{
	public interface IUserFactory
	{
		IStudentOptionBuilder CreateStudent(string firstName, string lastName, string email, string password);
		ILectorOptionBuilder CreateLector(string firstName, string lastName, string email, string password);
	}
}
