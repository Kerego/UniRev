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
			var userRepository = ServiceLocator.Get<IUserRepository>();
			var reviewRepository = ServiceLocator.Get<IReviewRepository>();

			//var seeder = ServiceLocator.Get<Seeder>();
			//seeder.Seed();

			System.Console.WriteLine("Users");
			foreach (var user in userRepository.Read())
				System.Console.WriteLine($" {user.Id, 4} | {user.FirstName, -10} | {user.Password, -10}");

			System.Console.WriteLine("Reviews");
			foreach (var review in reviewRepository.Read())
				System.Console.WriteLine($" {review.Id, 4} | {review.Rating,-10} | {review.Comment,-10}");


			System.Console.Read();
		}


		static Program()
		{
			ServiceLocator.RegisterAll();
		}
	}
}
