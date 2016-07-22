using System.Collections.Generic;
using System;
using UniRev.Domain.Interfaces;

namespace UniRev.Domain.Models
{
	public class Course : NamedEntity, IReviewable
	{
		public int Credits { get; protected set; }
		public ICollection<Review> Reviews { get; set; } = new List<Review>();
		public TimeSpan Duration { get; set; }

		protected Course()
		{
			
		}

		public Course(string name, int credits)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"{nameof(name)} is empty", nameof(name));
			if(credits < 1 || credits > 8)
				throw new ArgumentException($"{nameof(credits)} is out of boundary", nameof(credits));

			Name = name;
			Credits = credits;
		}

		public override string ToString() 
		{
			return $"Course {Name}";
		}
	}
}