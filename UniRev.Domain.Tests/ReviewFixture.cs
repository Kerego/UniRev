using System;
using UniRev.Domain.Models;
using UniRev.Factories;
using UniRev.Factories.Abstractions;
using Xunit;

namespace UniRev.Domain.Tests
{
	public class ReviewFixture
	{
		readonly IUserFactory _userFactory = new UserFactory();
		readonly IReviewFactory _reviewFactory = new ReviewFactory();
		readonly ICourseFactory _courseFactory = new CourseFactory();

		[Fact]
		public void ReviewConstructorShouldThrowOnNullReviewable()
		{
			//arrange
			Reviewable reviewable = null;
			User reviewer = _userFactory.CreateStudent("name", "ln", "a@d.c", "password").Complete();
			int rating = 4;

			//act
			var exception = Record.Exception(() => _reviewFactory.CreateReview(reviewable, reviewer, rating));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentNullException>(exception);
		}

		[Fact]
		public void ReviewConstructorShouldThrowOnNullUser()
		{
			//arrange
			Reviewable reviewable = _courseFactory.CreateCourse("course", 4).Complete();
			User reviewer = null;
			int rating = 4;

			//act
			var exception = Record.Exception(() => _reviewFactory.CreateReview(reviewable, reviewer, rating));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentNullException>(exception);
		}

		[Fact]
		public void ReviewConstructorShouldThrowOnNegativeRating()
		{
			//arrange
			Reviewable reviewable = _courseFactory.CreateCourse("course", 4).Complete();
			User reviewer = _userFactory.CreateStudent("name", "ln", "a@d.c", "password").Complete();
			int rating = -2;

			//act
			var exception = Record.Exception(() => _reviewFactory.CreateReview(reviewable, reviewer, rating));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentException>(exception);
		}

		[Fact]
		public void ReviewConstructorShouldThrowOnTooBigRating()
		{
			//arrange
			Reviewable reviewable = _courseFactory.CreateCourse("course", 4).Complete();
			User reviewer = _userFactory.CreateStudent("name", "ln", "a@d.c", "password").Complete();
			int rating = 7;

			//act
			var exception = Record.Exception(() => _reviewFactory.CreateReview(reviewable, reviewer, rating));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentException>(exception);
		}

		[Fact]
		public void ReviewConstructorShouldCreateOnCorrectValues()
		{
			//arrange
			Reviewable reviewable = _courseFactory.CreateCourse("course", 4).Complete();
			User reviewer = _userFactory.CreateStudent("name", "ln", "a@d.c", "password").Complete();
			int rating = 4;


			//act
			_reviewFactory.CreateReview(reviewable, reviewer, rating);

			//assert
			Assert.True(true);
		}

	}
}
