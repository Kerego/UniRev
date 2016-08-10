using System;
using System.Collections.Generic;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;
using UniRev.Factories.Abstractions.Builders;

namespace UniRev.Factories
{
	internal class CourseFactory : ICourseFactory
	{
		public ICourseOptionBuilder CreateCourse(string name, int credits)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"{nameof(name)} is empty", nameof(name));
			if (credits < 1 || credits > 8)
				throw new ArgumentException($"{nameof(credits)} is out of boundary", nameof(credits));

			var review = new Course(name, credits)
			{
				Reviews = new List<Review>(),
				Lessons = new List<Lesson>()
			};
			return new CourseOptionBuilder(review);
		}
		
		private class CourseOptionBuilder : OptionBuilder<Course>, ICourseOptionBuilder
		{
			internal CourseOptionBuilder(Course entity) : base(entity) { }

			public ICourseOptionBuilder WithDescription(string description)
			{
				Entity.Description = description;
				return this;
			}

			public ICourseOptionBuilder WithDuration(TimeSpan duration)
			{
				if(duration.TotalHours < 1 || duration.TotalHours > 160)
					throw new ArgumentException("{nameof(duration)} out of boundaries", nameof(duration));
				
				Entity.Duration = duration;
				return this;
			}
		}
	}

}