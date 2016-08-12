using System.Collections.Generic;
using System;

namespace UniRev.Domain.Models
{
	public class Course : Reviewable
	{
		public virtual IList<Lesson> Lessons { get; protected internal set; }
		public virtual string Name { get; protected set; }
		public virtual int Credits { get; protected set; }
		public virtual TimeSpan Duration { get; protected internal set; }
		public virtual string Description { get; protected internal set; }
		public override string ShortDescription { get; protected internal set; }

		protected Course()
		{
			
		}

		internal Course(string name, int credits)
		{
			Name = name;
			Credits = credits;
			ShortDescription = $"Course {name}";
		}

		public override string ToString() 
		{
			return $"Course {Name}";
		}
	}
}