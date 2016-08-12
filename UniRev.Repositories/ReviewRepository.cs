using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System.Collections.Generic;
using UniRev.Domain.Dtos;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;
using static NHibernate.Criterion.Projections;

namespace UniRev.Repositories
{
	internal class ReviewRepository : Repository<Review>, IReviewRepository
	{
		public ReviewRepository(ISession session) : base(session)
		{
		}

		public IList<ReviewableDetailsDto> GetReviewableDetails()
		{
			Review review = null;
			Reviewable reviewable = null;
			ReviewableDetailsDto dto = null;

			var query = _session
				.QueryOver(() => reviewable)
				.SelectList(list => list
					.SelectSubQuery(QueryOver.Of(() => review)
						.Where(() => review.Reviewable.Id == reviewable.Id)
						.Select(Conditional(
									Restrictions.Gt(Avg(() => review.Rating), 3.5),
									Constant("Good", NHibernateUtil.String),
									Conditional(Restrictions.Gt(Avg(() => review.Rating), 2),
										Constant("Moderate"),
										Constant("Bad"))))
						.Take(1))
						.WithAlias(() => dto.Reviews)
					.Select(() => reviewable.ShortDescription)
						.WithAlias(() => dto.Description))
				.TransformUsing(Transformers.AliasToBean<ReviewableDetailsDto>())
				.List<ReviewableDetailsDto>();

			return query;
		}

		public IList<ReviewDetailsDto> GetReviewsDetails()
		{
			Review review = null;
			User user = null;
			Reviewable reviewable = null;
			ReviewDetailsDto reviewDetails = null;

			var query = _session
				.QueryOver(() => review)
				.JoinAlias(() => review.User, () => user)
				.JoinAlias(() => review.Reviewable, () => reviewable)
				.SelectList(list => list
					.Select(() => review.Comment)
						.WithAlias(() => reviewDetails.Comment)
					.Select(() => review.Rating)
						.WithAlias(() => reviewDetails.Rating)
					.Select(() => user.FirstName)
						.WithAlias(() => reviewDetails.ReviewerFirstName)
					.Select(() => user.LastName)
						.WithAlias(() => reviewDetails.ReviewerLastName)
					.Select(() => reviewable.ShortDescription)
						.WithAlias(() => reviewDetails.Reviewable))
				.TransformUsing(Transformers.AliasToBean<ReviewDetailsDto>())
				.List<ReviewDetailsDto>();

			return query;
		}






	}
}
