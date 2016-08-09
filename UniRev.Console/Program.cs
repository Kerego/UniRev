using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;
using UniRev.Infrastructure;
using UniRev.Repositories.Interfaces;

namespace UniRev.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var repo = ServiceLocator.Get<IUserRepository>();
			var factory = ServiceLocator.Get<IUserFactory>();

			var student = factory
						.CreateStudent("Marian", "Bejenari", "test@test.test", "test")
						.WithAlmaMater("FAF-131")
						.Complete();

			var lector = factory
						.CreateLector("Test", "testl", "aha@mail.com", "drowssap")
						.WithOrganization("UTM")
						.Complete();

			repo.Create(student);
			repo.Create(lector);
			System.Console.WriteLine("   Id |    Name    | Password ");
			System.Console.WriteLine("-------------------------------");
			foreach (var user in repo.Read())
				System.Console.WriteLine($" {user.Id,4} | {user.FirstName,-10} | {user.Password,-10}");


			System.Console.Read();
		}

		static Program()
		{
			ServiceLocator.RegisterAll();
		}
	}
}
