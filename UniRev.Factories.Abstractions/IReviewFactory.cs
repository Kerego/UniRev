using UniRev.Domain.Models;
using UniRev.Factories.Abstractions.Builders;

namespace UniRev.Factories.Abstractions
{
	public interface IReviewFactory
	{
		IReviewOptionBuilder CreateReview(Reviewable reviewable, User reviewer, int rating);
	}
}
