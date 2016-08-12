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
			var lessonRepository = ServiceLocator.Get<ILessonRepository>();


			//var seeder = ServiceLocator.Get<Seeder>();
			//seeder.Seed();


			WriteLine("Statistics");
			foreach (var review in userRepository.GetUserReviewStats())
				WriteLine($"Id: {review.UserId,-3} | Name: {review.Username,-30} | Count: {review.ReviewsCount,-3} | Average Rating: {review.AverageRating,-3}");

			WriteLine("Reviews");
			foreach (var review in reviewRepository.GetReviewsDetails())
				WriteLine($"Reviewer: {review.Reviewer,-20} | Reviewable: {review.Reviewable,-30} | Comment: {review.Comment,-10} | Rating: {review.Rating,-5}");

			WriteLine("Lessons from top lectors");
			foreach (var lesson in lessonRepository.GetLessonsByLectorRating(1))
				WriteLine($"Lector: {lesson.LectorName,-25} | Course: {lesson.CourseName,-10} | Rating: {lesson.Rating, -5}");

			WriteLine("Lessons");
			foreach (var lesson in lessonRepository.GetLessons())
				WriteLine($"Lector: {lesson.LectorName,-20} | Course: {lesson.CourseName,-10} | Rating: {lesson.Rating, -5}");

			WriteLine("Reviewables");
			foreach (var reviewable in reviewRepository.GetReviewableDetails())
				WriteLine($"Reviewable: {reviewable.Description,-35} | Reviews: {reviewable.Reviews} ");

			ReadKey();
		}

		static Program()
		{
			ServiceLocator.RegisterAll();
		}
	}
}
