﻿using System;
using System.Collections.Generic;

namespace UniRev.Domain.Models
{
	public class Lector : User
	{
		public virtual string Organization { get; protected internal set; }
		public virtual LectorReviewInfo LectorReviewInfo { get; protected internal set; }
		public virtual IList<Lesson> Lessons { get; protected internal set; }

		internal Lector(string firstName, string lastName, string email, string password) : base(firstName, lastName, email, password)
		{
			Lessons = new List<Lesson>();
			LectorReviewInfo = new LectorReviewInfo
			{
				Reviews = new List<Review>(),
				ShortDescription = $"Lector {firstName} {lastName}"
			};
		}

		protected Lector()
		{

		}
	}
}
