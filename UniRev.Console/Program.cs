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

			var statistics = userRepository.GetStatistics();

			WriteLine($"Users {statistics.TotalUsers, 4} | Reviews {statistics.TotalReviews, 4} | Courses {statistics.TotalCourses} | Lessons {statistics.TotalLessons}");

			//WriteLine("Lector with reviews of 5");
			//foreach (var lector in userRepository.GetLectorsReviewedWithRating(5))
			//	WriteLine($"Id: {lector.Id,-3} | Name: {lector.Username,-30}");


			//WriteLine("\r\nBest Lector for course 31");
			//var bestLector = userRepository.GetBestLectorForCourse(31);
			//WriteLine($"Id: {bestLector.Id,-3} | Name: {bestLector.Username,-30}");


			//WriteLine("\r\nMost Recent Review for Lector 18");
			//var recentReview = reviewRepository.GetMostRecentReview(18);
			//WriteLine($"Reviewer: {recentReview.Reviewer,-20} | Comment: {recentReview.Comment,-10} | Rating: {recentReview.Rating,-5}");


			//WriteLine("\r\nUser Reviews Statistics");
			//foreach (var review in userRepository.GetUserReviewStats())
			//	WriteLine($"Id: {review.UserId,-3} | Name: {review.Username,-30} | Count: {review.ReviewsCount,-3} | Average Rating: {review.AverageRating,-3}");


			//WriteLine("\r\nLessons from lectors with rating > 3.5");
			//foreach (var lesson in lessonRepository.GetLessonsByLectorRating(3.5))
			//	WriteLine($"Lector: {lesson.LectorName,-25} | Course: {lesson.CourseName,-10} | Rating: {lesson.LessonRating,-5}");


			//WriteLine("\r\nLessons Info");
			//foreach (var lesson in lessonRepository.GetLessons())
			//	WriteLine($"Lector: {lesson.LectorName,-20} | Course: {lesson.CourseName,-10} | Rating: {lesson.LessonRating,-5}");


			//WriteLine("\r\nReviewables Details");
			//foreach (var reviewable in reviewRepository.GetReviewableDetails())
			//	WriteLine($"Reviewable: {reviewable.Description,-35} | Reviews: {reviewable.Reviews} ");


			//WriteLine("\r\nReviews Details");
			//foreach (var review in reviewRepository.GetReviewsDetails())
			//	WriteLine($"Reviewer: {review.Reviewer,-20} | Reviewable: {review.Reviewable,-30} | Comment: {review.Comment,-10} | Rating: {review.Rating,-5}");


			ReadKey();
		}

		static Program()
		{
			ServiceLocator.RegisterAll();
		}
	}
}
