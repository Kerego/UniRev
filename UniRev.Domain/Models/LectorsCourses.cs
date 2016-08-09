using System.Collections;
using System.Collections.Generic;

namespace UniRev.Domain.Models
{
	public class Lesson : Entity
	{
		public virtual Lector Lector { get; protected set; }
		public virtual Course Course { get; protected set; }
		public virtual IList<Schedule> Schedules { get; protected set; }

		protected Lesson() { }
	}
}
