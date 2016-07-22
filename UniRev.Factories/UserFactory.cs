using System;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;

namespace UniRev.Factories
{
	internal class UserFactory : IUserFactory
	{
		public OptionBuilder<Student> CreateStudent(string name, string password)
		{
			var review = new Student(name, password);
			return new StudentBuilder(review);
		}

		public class StudentBuilder : OptionBuilder<Student>
		{
			public StudentBuilder(Student entity) : base(entity) { }

			public StudentBuilder WithGroup(string group)
			{
				Entity.Group = group;
				return this;
			}
		}
	}
}