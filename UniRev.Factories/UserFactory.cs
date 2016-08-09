using System;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;
using UniRev.Factories.Abstractions.Builders;

namespace UniRev.Factories
{
	internal class UserFactory : IUserFactory
	{
		public ILectorOptionBuilder CreateLector(string firstName, string lastName, string email, string password)
		{
			Validate(firstName, lastName, email, password);
			var lector = new Lector(firstName, lastName, email, password);
			return new LectorOptionBuilder(lector);
		}

		public IStudentOptionBuilder CreateStudent(string firstName, string lastName, string email, string password)
		{
			Validate(firstName, lastName, email, password);
			var student = new Student(firstName, lastName, email, password);
			return new StudentOptionBuilder(student);
		}

		protected void Validate(string firstName, string lastName, string email, string password)
		{
			if (string.IsNullOrWhiteSpace(firstName))
				throw new ArgumentException($"{nameof(firstName)} is empty", nameof(firstName));
			if (string.IsNullOrWhiteSpace(lastName))
				throw new ArgumentException($"{nameof(lastName)} is empty", nameof(lastName));
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentException($"{nameof(password)} is empty", nameof(password));
			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentException($"{nameof(email)} is empty", nameof(email));
		}

		internal class LectorOptionBuilder : OptionBuilder<Lector>, ILectorOptionBuilder
		{
			internal LectorOptionBuilder(Lector entity) : base(entity) { }
			public ILectorOptionBuilder WithOrganization(string organization)
			{
				Entity.Organization = organization;
				return this;
			}
		}

		internal class StudentOptionBuilder : OptionBuilder<Student>, IStudentOptionBuilder
		{
			internal StudentOptionBuilder(Student entity) : base(entity) { }
			public IStudentOptionBuilder WithAlmaMater(string group)
			{
				Entity.AlmaMater = group;
				return this;
			}
		}
	}
}