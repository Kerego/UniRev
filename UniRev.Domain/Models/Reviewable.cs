using System.Collections.Generic;
using UniRev.Domain.Models;

namespace UniRev.Domain.Models
{
	public abstract class Reviewable : Entity
	{
		public abstract string ShortDescription { get; protected internal set; }
		public virtual IList<Review> Reviews { get; protected internal set; }
	}
}