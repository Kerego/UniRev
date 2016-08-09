using System.Collections.Generic;
using UniRev.Domain.Models;

namespace UniRev.Domain.Models
{
	public class Reviewable : Entity
	{
		public virtual IList<Review> Reviews { get; set; }
	}
}