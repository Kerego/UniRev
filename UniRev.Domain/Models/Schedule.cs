using System;

namespace UniRev.Domain.Models
{
	public class Schedule : Entity
	{
		public virtual Lesson Lesson { get; protected set; }
		public virtual DateTimeOffset Time { get; protected set; }
		public virtual DayOfWeek Day { get; protected set; }
		public virtual string Address { get; protected set; }

		protected Schedule()
		{
		}
	}
}
