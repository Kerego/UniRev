using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;

namespace UniRev.Factories.Abstractions
{
	public interface ICourseFactory
	{
		OptionBuilder<Course> CreateCourse(string name, int credits);
	}
}
