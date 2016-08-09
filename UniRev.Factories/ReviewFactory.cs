using System;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;
using UniRev.Factories.Abstractions.Builders;

namespace UniRev.Factories
{
	internal class ReviewFactory : IReviewFactory
	{
		public IReviewOptionBuilder CreateReview(Reviewable reviewable, User reviewer, int rating)
		{
			Validate(reviewable, reviewer, rating);
			var review = new Review(reviewable, reviewer, rating);
			return new ReviewOptionBuilder(review);
		}

		protected void Validate(Reviewable reviewable, User reviewer, int rating)
		{
			if (reviewable == null)
				throw new ArgumentNullException($"{nameof(reviewable)} is null", nameof(reviewable));
			if (reviewer == null)
				throw new ArgumentNullException($"{nameof(reviewer)} is null", nameof(reviewer));
			if (rating < 1 || rating > 5)
				throw new ArgumentException($"{nameof(rating)} exceeds boundaries", nameof(rating));
		}

		public class ReviewOptionBuilder : OptionBuilder<Review>, IReviewOptionBuilder
		{
			public ReviewOptionBuilder(Review entity) : base(entity) { }

			public IReviewOptionBuilder WithAnonymous(bool isAnonymous)
			{
				Entity.IsAnonymous = isAnonymous;
				return this;
			}
			
			public IReviewOptionBuilder WithComment(string comment)
			{
				if(string.IsNullOrWhiteSpace(comment))
					throw new ArgumentException($"{nameof(comment)} is empty", nameof(comment));
				Entity.Comment = comment;
				return this;
			}
		}
	}
}