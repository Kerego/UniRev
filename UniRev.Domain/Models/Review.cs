using System;

namespace UniRev.Domain.Models
{
	public class Review : Entity
	{
		public virtual int Rating { get; protected set; }
		public virtual Reviewable Reviewable { get; protected set; }
		public virtual User User { get; protected set; }
		public virtual DateTimeOffset Timestamp { get; protected set; }
		public virtual bool IsAnonymous { get; protected internal set; }
		public virtual string Comment { get; protected internal set; }

		internal Review(Reviewable reviewable, User reviewer, int rating)
		{
			User = reviewer;
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
	Reviewer: {User}
	Reviewable: {Reviewable}
	Anonymous: {IsAnonymous}
	Timestamp: {Timestamp}";
		}
	}
}