using System;
using UniRev.Domain.Interfaces;
using UniRev.Domain.Models;
using Xunit;

namespace UniRev.Domain.Tests
{
	public class ReviewFixture
	{
		[Fact]
		public void ReviewConstructorShouldThrowOnNullReviewable()
		{
			//arrange
			IReviewable reviewable = null;
			IReviewer reviewer = new Student("name", "password");
			int rating = 4;

			//act
			var exception = Record.Exception(() => new Review(reviewable, reviewer, rating));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentNullException>(exception);
		}

		[Fact]
		public void ReviewConstructorShouldThrowOnNullReviewer()
		{
			//arrange
			IReviewable reviewable = new Course("course", 4);
			IReviewer reviewer = null;
			int rating = 4;

			//act
			var exception = Record.Exception(() => new Review(reviewable, reviewer, rating));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentNullException>(exception);
		}

		[Fact]
		public void ReviewConstructorShouldThrowOnNegativeRating()
		{
			//arrange
			IReviewable reviewable = new Course("course", 4);
			IReviewer reviewer = new Student("name", "password");
			int rating = -2;

			//act
			var exception = Record.Exception(() => new Review(reviewable, reviewer, rating));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentException>(exception);
		}

		[Fact]
		public void ReviewConstructorShouldThrowOnTooBigRating()
		{
			//arrange
			IReviewable reviewable = new Course("course", 4);
			IReviewer reviewer = new Student("name", "password");
			int rating = 7;

			//act
			var exception = Record.Exception(() => new Review(reviewable, reviewer, rating));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentException>(exception);
		}
		[Fact]
		public void ReviewConstructorShouldCreateOnCorrectValues()
		{
			//arrange
			IReviewable reviewable = new Course("course", 4);
			IReviewer reviewer = new Student("name", "password");
			int rating = 4;
			

			//act
			new Review(reviewable, reviewer, rating);

			//assert
			Assert.True(true);
		}

	}
}
