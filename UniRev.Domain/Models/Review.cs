using System;
using UniRev.Domain.Interfaces;

namespace UniRev.Domain.Models
{
	public class Review : Entity
	{
		public int Rating { get; protected set; }
		public IReviewable Reviewable { get; protected set; }
		public IReviewer Reviewer { get; protected set; }
		public DateTimeOffset Timestamp { get; protected set; }
		public bool IsAnonymous { get; set; }
		public string Comment { get; set; }

		public Review(IReviewable reviewable, IReviewer reviewer, int rating)
		{

			if(reviewable == null)
				throw new ArgumentNullException($"{nameof(reviewable)} is null", nameof(reviewable));
			if(reviewer == null)
				throw new ArgumentNullException($"{nameof(reviewer)} is null", nameof(reviewer));
			if(rating < 1 || rating > 5)
				throw new ArgumentException($"{nameof(rating)} exceeds boundaries", nameof(rating));

			Reviewer = reviewer;
			Reviewable = reviewable;
			Rating = rating;
			Timestamp = DateTime.Now;
		}

		protected Review()
		{

		}

		public override string ToString()
		{
			return $@"Review {Id}
	Rating: {Rating}
	Comment: {Comment}
	Reviewer: {Reviewer?.Description}
	Reviewable: {Reviewable}
	Anonymous: {IsAnonymous}
	Timestamp: {Timestamp}";
		}
	}
}