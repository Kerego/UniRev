using UniRev.Domain.Interfaces;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions;

namespace UniRev.Factories.Abstractions
{
    public interface IReviewFactory
    {
		IReviewOptionBuilder CreateReview(IReviewable reviewable, IReviewer reviewer, int rating);

	}
}
