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

		public IList<NamedUserDto> GetLectorsReviewedWithRating(int rating)
		{
			Lector lector = null;
			Review review = null;
			NamedUserDto dto = null;

			var subquery = QueryOver
				.Of(() => review)
				.Where(() => review.Reviewable.Id == lector.LectorReviewInfo.Id &&
							review.Rating == rating)
				.Select(x => x.Id);

			var query = _session.QueryOver(() => lector)
							.WithSubquery.WhereExists(subquery)
							.SelectList(list => list
								.Select(() => lector.FirstName)
									.WithAlias(() => dto.FirstName)
								.Select(() => lector.LastName)
									.WithAlias(() => dto.LastName)
								.Select(() => lector.Id)
									.WithAlias(() => dto.Id))
							.TransformUsing(Transformers.AliasToBean<NamedUserDto>())
							.List<NamedUserDto>();
			return query;
		}

		public NamedUserDto GetBestLectorForCourse(long courseId)
		{
			Lector lector = null;
			Review review = null;
			Lesson lesson = null;
			NamedUserDto dto = null;

			var query = _session.QueryOver(() => lesson)
						.JoinAlias(() => lesson.Lector, () => lector)
						.JoinAlias(() => lesson.Reviews, () => review)
						.Where(() => lesson.Course.Id == courseId)
						.SelectList(list => list
							.SelectGroup(() => lector.FirstName)
								.WithAlias(() => dto.FirstName)
							.SelectGroup(() => lector.LastName)
								.WithAlias(() => dto.LastName)
							.SelectGroup(() => lector.Id)
								.WithAlias(() => dto.Id)
						)
						.TransformUsing(Transformers.AliasToBean<NamedUserDto>())
						.OrderBy(Avg(() => review.Rating)).Desc
						.Take(1)
						.SingleOrDefault<NamedUserDto>();

			return query;
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

		protected IFutureValue<long> GetFutureLongCount<T>() where T : Entity
		{
			return _session.QueryOver<T>()
					.Select(RowCountInt64())
					.FutureValue<long>();
	}

		public StatisticsDto GetStatistics()
		{
			var userQuery = GetFutureLongCount<User>();
			var reviewQuery = GetFutureLongCount<Review>();
			var courseQuery = GetFutureLongCount<Course>();
			var lessonQuery = GetFutureLongCount<Lesson>();
			
			return new StatisticsDto
			{
				TotalCourses = courseQuery.Value,
				TotalLessons = lessonQuery.Value,
				TotalReviews = reviewQuery.Value,
				TotalUsers = userQuery.Value
			};
		}
	}
}
