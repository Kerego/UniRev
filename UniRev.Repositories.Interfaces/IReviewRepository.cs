using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Domain.Dtos;
using UniRev.Domain.Models;

namespace UniRev.Repositories.Interfaces
{
	public interface IReviewRepository : IRepository<Review>
	{
		IList<ReviewDetailsDto> GetReviewsDetails();
		IList<ReviewableDetailsDto> GetReviewableDetails();
		ReviewDetailsDto GetMostRecentReview(long reviewableId);
	}
}
