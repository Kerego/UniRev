using UniRev.Factories.Abstractions.Builders;

namespace UniRev.Factories.Abstractions
{
	public interface ICourseFactory
	{
		ICourseOptionBuilder CreateCourse(string name, int credits);
	}
}
