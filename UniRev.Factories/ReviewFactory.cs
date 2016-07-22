using System;
using UniRev.Domain.Interfaces;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;

namespace UniRev.Factories
{
	internal class ReviewFactory : IReviewFactory
	{
		public OptionBuilder<Review> CreateReview(IReviewable reviewable, IReviewer reviewer, int rating)
		{
			var review = new Review(reviewable, reviewer, rating, string.Empty);
			return new ReviewOptionBuilder(review);
		}

		public class ReviewOptionBuilder : OptionBuilder<Review>
		{
			public ReviewOptionBuilder(Review entity) : base(entity) { }

			public ReviewOptionBuilder WithAnonymous(bool isAnonymous)
			{
				Entity.IsAnonymous = isAnonymous;
				return this;
			}
			
			public ReviewOptionBuilder WithComment(string comment)
			{
				if(string.IsNullOrWhiteSpace(comment))
					throw new ArgumentException($"{nameof(comment)} is empty", nameof(comment));
				Entity.Comment = comment;
				return this;
			}
		}
	}
}