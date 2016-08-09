using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Factories.Abstractions;
using UniRev.Repositories.Interfaces;

namespace UniRev.Console
{
	public class Seeder
	{
		private readonly IUserFactory _userFactory;
		private readonly IUserRepository _userRepository;
		private readonly ICourseFactory _courseFactory;
		private readonly ICourseRepository _courseRepository;
		private readonly IReviewFactory _reviewFactory;
		private readonly IReviewRepository _reviewRepository;

		public Seeder(	IUserFactory userFactory, 
						IUserRepository userRepository, 
						ICourseRepository courseRepository, 
						ICourseFactory courseFactory, 
						IReviewRepository reviewRepository, 
						IReviewFactory reviewFactory)
		{
			this._userFactory = userFactory;
			_userRepository = userRepository;
			_courseRepository = courseRepository;
			_courseFactory = courseFactory;
			_reviewRepository = reviewRepository;
			_reviewFactory = reviewFactory;
		}

		public void Seed()
		{
			var course1 = _courseFactory.CreateCourse("OOP", 5).Complete();
			var course2 = _courseFactory.CreateCourse("APA", 3).Complete();
			var course3 = _courseFactory.CreateCourse("DM", 6).WithDuration(TimeSpan.FromHours(2)).Complete();
			var course4 = _courseFactory.CreateCourse("MS", 4).WithDescription("Media and compression").Complete();
			var course5 = _courseFactory.CreateCourse("MIDPS", 5).Complete();

			var student1 = _userFactory.CreateStudent("Marian", "Bejenari", "marian@blabla.md", "qewyrt412").WithAlmaMater("UTM").Complete();
			var student2 = _userFactory.CreateStudent("Alina", "Mocanas", "alina@blabla.md", "qewyrt412").Complete();
			var student3 = _userFactory.CreateStudent("Dorin", "Balan", "dorin@blabla.md", "qewyrt412").Complete();
			var student4 = _userFactory.CreateStudent("Igor", "Shopin", "igor@blabla.usm", "qewyrt412").WithAlmaMater("USM").Complete();

			var lector1 = _userFactory.CreateLector("Irina", "Cojanu", "irina@lector.utm", "qsddsad13").WithOrganization("UTM").Complete();
			var lector2 = _userFactory.CreateLector("Nina", "Sava", "Nina@lector.oratorica", "qsddsad13").WithOrganization("Oratorica").Complete();

			_userRepository.Create(student1);
			_userRepository.Create(student2);
			_userRepository.Create(student3);
			_userRepository.Create(student4);

			_userRepository.Create(lector1);
			_userRepository.Create(lector2);

			_courseRepository.Create(course1);
			_courseRepository.Create(course2);
			_courseRepository.Create(course3);
			_courseRepository.Create(course4);
			_courseRepository.Create(course5);


			var review1 = _reviewFactory.CreateReview(course1, student1, 4).WithComment("Nice").Complete();
			var review2 = _reviewFactory.CreateReview(course2, student1, 2).WithComment("Boring").WithAnonymous(true).Complete();
			var review3 = _reviewFactory.CreateReview(lector1.LectorReviewInfo, lector2, 4).WithComment("Ok").Complete();

			_reviewRepository.Create(review1);
			_reviewRepository.Create(review2);
			_reviewRepository.Create(review3);


		}
	}
}
