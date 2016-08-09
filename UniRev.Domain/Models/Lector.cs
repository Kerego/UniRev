using System;
using System.Collections.Generic;

namespace UniRev.Domain.Models
{
	public class Lector : User
	{
		public virtual string Organization { get; protected internal set; }
		public virtual LectorReviewInfo LectorReviewInfo { get; protected set; }
		public virtual IList<Lesson> Lessons { get; set; }

		internal Lector(string firstName, string lastName, string email, string password) : base(firstName, lastName, email, password)
		{
			LectorReviewInfo = new LectorReviewInfo();
		}

		protected Lector()
		{

		}
	}
}
