using System;
using UniRev.Domain.Models;

namespace UniRev.Factories.Abstractions.Builders
{
	public interface ICourseOptionBuilder : IOptionBuilder<Course>
	{
		ICourseOptionBuilder WithDuration(TimeSpan duration);
		ICourseOptionBuilder WithDescription(string description);
	}
}
