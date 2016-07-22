using System;
using UniRev.Domain.Interfaces;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;
using UniRev.Infrastructure;
using Xunit;

namespace UniRev.Tests
{
	public class ReviewFactoryTests : IClassFixture<RegisterDependencies>
	{
		private readonly IReviewFactory factory = ServiceLocator.Get<IReviewFactory>();
		private readonly User st = new Student("dads", "dsada");

		[Theory]
		[InlineData(null, null, -2)]
		[InlineData(null, null, 8)]
		public void TestCreateReviewShouldThrowOnNullReviewable(IReviewable reviewable, IReviewer reviewer, int rating)
		{
			//arrange
			var student = new Student("dads", "dsad");
			var course = new Course("dsfs", 5);

			var exception = Record.Exception(() => factory.CreateReview(reviewable, reviewer, rating).Complete());
			Assert.NotNull(exception);
			Assert.IsAssignableFrom<ArgumentException>(exception);
		}

		[Fact]
		public void ShouldThrow()
		{
			//Assert.ThrowsAny<ArgumentException>(() => 
			//factory.CreateReview(null, reviewer, rating)
			//.WithAnonymous(false)
			//.WithComment(null)
			//.Complete());
		}
	}
}
