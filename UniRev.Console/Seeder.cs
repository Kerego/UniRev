using System;
using System.Collections.Generic;
using System.Linq;
using UniRev.Domain.Models;
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
		private readonly ILessonFactory _lessonFactory;
		private readonly ILessonRepository _lessonRepository;

		public Seeder(IUserFactory userFactory,
						IUserRepository userRepository,
						ICourseRepository courseRepository,
						ICourseFactory courseFactory,
						IReviewRepository reviewRepository,
						IReviewFactory reviewFactory,
						ILessonFactory lessonFactory,
						ILessonRepository lessonRepository)
		{
			_userFactory = userFactory;
			_userRepository = userRepository;
			_courseRepository = courseRepository;
			_courseFactory = courseFactory;
			_reviewRepository = reviewRepository;
			_reviewFactory = reviewFactory;
			_lessonFactory = lessonFactory;
			_lessonRepository = lessonRepository;
		}


		public void Seed()
		{
			List<Course> courses = GenerateCourses();
			List<Student> students = GenerateStudents();
			List<Lector> lectors = GenerateLectors();


			students.ForEach(_userRepository.Create);
			lectors.ForEach(_userRepository.Create);
			courses.ForEach(_courseRepository.Create);


			List<Lesson> lessons = GenerateLessons(lectors, courses);
			lessons.ForEach(_lessonRepository.Create);


			var reviewables = courses
				.Concat<Reviewable>(lectors.Select(x => x.LectorReviewInfo))
				.Concat(lessons).ToList();
			var reviewers = students.Concat<User>(lectors).ToList();

			var reviews = GenerateReviews(reviewables, reviewers);

			reviews.ForEach(_reviewRepository.Create);

		}

		private List<Student> GenerateStudents()
		{
			List<Student> students = new List<Student>();
			var rand = new Random();

			var studentNames = new List<string>
			{
				"Marian", "Alina", "Dorin", "Irina", "Artur",
				"Vasea", "Valeriu", "Dima", "Sergiu", "Julia",
				"Anastasia", "Denis", "Mihaela", "Alexandru"
			};

			var studentSurnames = new List<string>
			{
				"Bejenari", "Balan", "Mocanas", "Mazur", "Cojanu",
				"Strajescu", "Cojuhari", "Birsanu", "Bordea",
				"Matcovschi", "Haraz", "Sisianu", "Gorenco"
			};

			var almaMatters = new List<string>()
			{
				"UTM", "USM", "ULIM", "USMF"
			};

			var password = "testPassword";


			while (students.Count < 100)
			{
				var name = studentNames.RandomItem();
				var surname = studentSurnames.RandomItem();

				var studentBuilder = _userFactory
					.CreateStudent(name, surname, $"{name}@{surname}.md", password);
				if (rand.NextDouble() > 0.5)
					studentBuilder = studentBuilder.WithAlmaMater(almaMatters.RandomItem());
				students.Add(studentBuilder.Complete());
			}
			return students;
		}


		private List<Lector> GenerateLectors()
		{
			List<Lector> lectors = new List<Lector>();
			var rand = new Random();

			var lectorNames = new List<string>
			{
				"Viorel", "Alex", "Nina", "Irina",
				"Elena", "Sava", "Ivan", "Mihai",
				"Mihaela"
			};

			var lectorSurnames = new List<string>
			{
				"Bostan", "Railean", "Sava", "Cojanu",
				"Virtosu", "Zarea", "Kulev", "Balan",
				"Mugureanu"
			};

			var organizations = new List<string>()
			{
				"UTM", "USM", "ULIM", "USMF"
			};

			var password = "testPassword";


			while(lectors.Count < 30)
			{
				var name = lectorNames.RandomItem();
				var surname = lectorSurnames.RandomItem();

				var lectorBuilder = _userFactory
					.CreateLector(name, surname, $"{name}@{surname}.md", password);

				if (rand.NextDouble() > 0.5)
					lectorBuilder = lectorBuilder.WithOrganization(organizations.RandomItem());

				lectors.Add(lectorBuilder.Complete());
			}
			return lectors;
		}

		public List<Lesson> GenerateLessons(List<Lector> lectors, List<Course> courses)
		{
			List<Lesson> lessons = new List<Lesson>();

			while (lessons.Count < 50)
			{
				var lector = lectors.RandomItem();
				var course = courses.RandomItem();
				if (lessons.Any(x => x.Course == course && x.Lector == lector))
					continue;
				
				var lesson = _lessonFactory
					.CreateLesson(lector, course)
					.Complete();
				lessons.Add(lesson);
			}

			return lessons;
		}

		public List<Review> GenerateReviews(List<Reviewable> reviewables, List<User> reviewers)
		{
			List<Review> reviews = new List<Review>();

			var rand = new Random();

			var comments = new List<string>
			{
				"Ok", "Nice", "Boring", "Cool", "Merge",
				"Sku4no", "Lorem", "Impsum", "Dolum"
			};
			

			while(reviews.Count < 800)
			{
				var reviewer = reviewers.RandomItem();
				var reviewable = reviewables.RandomItem();

				if (reviews.Any(x => x.Reviewable == reviewable && x.User == reviewer))
					continue;

				if ((reviewer as Lector)?.LectorReviewInfo == reviewable)
					continue;

				var reviewBuilder = _reviewFactory
					.CreateReview(reviewable, reviewer, rand.Next(1, 6));

				if (rand.NextDouble() > 0.5)
					reviewBuilder = reviewBuilder.WithComment(comments.RandomItem());
				if (rand.NextDouble() > 0.5)
					reviewBuilder = reviewBuilder.WithAnonymous(true);

				reviews.Add(reviewBuilder.Complete());
			}

			return reviews;
		}


		private List<Course> GenerateCourses()
		{
			List<Course> courses = new List<Course>();
			var rand = new Random();

			var courseNames = new List<string>
			{
				"OOP",
				"APA",
				"MD",
				"Math",
				"LFPC",
				"TPI",
				"MIDPS",
				"CN",
				"C",
				"C++",
				"WP",
				"MS"
			};


			for (int i = 0; i < courseNames.Count; i++)
			{
				var courseBuilder = _courseFactory
					.CreateCourse(courseNames[i], rand.Next(1, 9));
				if (rand.NextDouble() > 0.5)
					courseBuilder = courseBuilder.WithDuration(TimeSpan.FromHours(rand.Next(1, 160)));
				courses.Add(courseBuilder.Complete());
			}
			return courses;
		}
	}

	public static class Extensions
	{
		private static Random rand = new Random();
		public static T RandomItem<T>(this List<T> list)
		{
			return list[rand.Next(list.Count)];
		}
	}
}
