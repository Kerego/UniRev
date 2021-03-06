﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;
using UniRev.Factories.Abstractions.Builders;

namespace UniRev.Factories
{
	internal class LessonFactory : ILessonFactory
	{
		public ILessonOptionBuilder CreateLesson(Lector lector, Course course)
		{
			var lesson = new Lesson(lector, course)
			{
				Schedules = new List<Schedule>(),
				Reviews = new List<Review>(),
				ShortDescription = $"Lesson {course.Name}-{lector.FirstName} {lector.LastName }"
			};
			lector.Lessons.Add(lesson);
			course.Lessons.Add(lesson);
			return new LessonOptionBuilder(lesson);
		}

		private class LessonOptionBuilder : OptionBuilder<Lesson>, ILessonOptionBuilder
		{
			public LessonOptionBuilder(Lesson entity) : base(entity)
			{
			}
		}
	}
}
