using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;
using UniRev.Infrastructure;
using UniRev.Repositories.Interfaces;
using static System.Console;

namespace UniRev.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var userRepository = ServiceLocator.Get<IUserRepository>();
			var reviewRepository = ServiceLocator.Get<IReviewRepository>();
			var student = (Student)userRepository.GetById(1);
			
			//var seeder = ServiceLocator.Get<Seeder>();
			//seeder.Seed();

			WriteLine("Users");
			foreach (var user in userRepository.Read())
				WriteLine($" {user.Id, 4} | {user.FirstName, -10} | {user.Password, -10} | {(user as Student)?.AlmaMater ?? (user as Lector)?.Organization ?? "Unset" } ");

			WriteLine("Reviews");
			foreach (var review in reviewRepository.Read())
				WriteLine($" {review.Id, 4} | {review.Rating, -10} | {review.Comment, -10}");

			ReadKey();
		}

		static Program()
		{
			ServiceLocator.RegisterAll();
		}
	}
}
