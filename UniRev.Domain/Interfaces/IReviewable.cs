using System.Collections.Generic;
using UniRev.Domain.Models;

namespace UniRev.Domain.Interfaces
{
	public interface IReviewable
	{
		ICollection<Review> Reviews { get; set; }
	}
}