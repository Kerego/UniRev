using System;
using UniRev.Domain.Interfaces;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;

namespace UniRev.Factories
{
	internal class ReviewFactory : IReviewFactory
	{
		public IReviewOptionBuilder CreateReview(IReviewable reviewable, IReviewer reviewer, int rating)
		{
			var review = new Review(reviewable, reviewer, rating);
			return new ReviewOptionBuilder(review);
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