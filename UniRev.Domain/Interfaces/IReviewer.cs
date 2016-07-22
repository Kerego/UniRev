using System.Collections.Generic;
using UniRev.Domain.Models;

namespace UniRev.Domain.Interfaces
{
	public interface IReviewer
	{
		ICollection<Review> Reviews { get; set; }
		string Description { get; }
	}
}