using System;
using System.Collections;
using System.Collections.Generic;

namespace UniRev.Domain.Models
{
	public class Lesson : Reviewable
	{
		public virtual Lector Lector { get; protected set; }
		public virtual Course Course { get; protected set; }
		public virtual IList<Schedule> Schedules { get; protected internal set; }
		public override string ShortDescription { get; protected internal set; }

		internal Lesson(Lector lector, Course course)
		{
			Lector = lector;
			Course = course;
		}

		protected Lesson() { }
	}
}
