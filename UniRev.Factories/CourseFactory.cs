using System;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;

namespace UniRev.Factories
{
	internal class CourseFactory : ICourseFactory
	{

		public OptionBuilder<Course> CreateCourse(string name, int credits)
		{
			var review = new Course(name, credits);
			return new CourseOptionBuilder(review);
		}
		
		public class CourseOptionBuilder : OptionBuilder<Course>
		{
			public CourseOptionBuilder(Course entity) : base(entity) { }

			public CourseOptionBuilder WithDuration(TimeSpan duration)
			{
				if(duration.TotalHours < 1 || duration.TotalHours > 160)
					throw new ArgumentException("{nameof(duration)} out of boundaries", nameof(duration));
				
				Entity.Duration = duration;
				return this;
			}
		}
	}

}