using System;
using System.Collections.Generic;
using NHibernate;
using UniRev.Domain.Dtos;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;
using NHibernate.Transform;
using System.Linq;
using static NHibernate.Criterion.Projections;
using static NHibernate.Criterion.Restrictions;
using NHibernate.Criterion;

namespace UniRev.Repositories
{
	internal class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(ISession session) : base(session) { }

		public void ChangePassword(long id, string newPassword)
		{
			var user = _session.Get<User>(id);
			user?.SetPassword(newPassword);
			_session.Update(user);
		}

		public IList<Lector> GetBestTeacherForCourse(long courseId)
		{
			Lector lector = null;
			Review review = null;
			Lesson lesson = null;

			//var query = _session.QueryOver(() => lector)
			//				.JoinAlias(() => lector.Lessons, () => lesson)
			//				.JoinAlias(() => lesson.Reviews, () => review)
			//				.Where(() => lesson.Course.Id == courseId)
			//				.WithSubquery
			//				.WhereAll(() => review.Rating > QueryOver
			//												.Of<Review>()
			//												.Select(x => x.Rating)
			//												.As<int>())

			return null;
		}

		public IList<UserReviewsDetailsDto> GetUserReviewStats()
		{
			User user = null;
			Review review = null;
			UserReviewsDetailsDto dto = null;
			NamedUserDto namedDto = null;

			var subquery = _session.QueryOver(() => user)
				.SelectList(list => list
					.Select(x => x.Id).WithAlias(() => namedDto.Id)
					.Select(x => x.FirstName).WithAlias(() => namedDto.FirstName)
					.Select(x => x.LastName).WithAlias(() => namedDto.LastName))
				.TransformUsing(Transformers.AliasToBean<NamedUserDto>())
				.Future<NamedUserDto>();

			var query = _session.QueryOver(() => review)
				.SelectList(list => list
					.SelectGroup(() => review.User.Id)
						.WithAlias(() => dto.UserId)
					.SelectCount(() => review.Id)
						.WithAlias(() => dto.ReviewsCount)
					.SelectAvg(() => review.Rating)
						.WithAlias(() => dto.AverageRating))
				.Where(Gt(Count(Property(() => review.User.Id)), 1))
				.TransformUsing(Transformers.AliasToBean<UserReviewsDetailsDto>())
				.Future<UserReviewsDetailsDto>();


			var enumerated = query.ToList();

			foreach (var item in enumerated)
				item.Username = subquery.First(x => x.Id == item.UserId).Username;

			return enumerated;

		}
	}
}
