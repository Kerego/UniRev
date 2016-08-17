using NHibernate;
using UniRev.Domain.Dtos;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;
using NHibernate.Criterion;
using static NHibernate.Criterion.Projections;
using NHibernate.Transform;
using System.Collections.Generic;
using NHibernate.SqlCommand;

namespace UniRev.Repositories
{
	internal class LessonRepository : Repository<Lesson>, ILessonRepository
	{
		public LessonRepository(ISession session) : base(session)
		{
		}
		
		public IList<LessonDetailsDto> GetLessonsByLectorRating(double minimalLectorRating) =>
			GetLessonsDynamic(minimalLectorRating);

		private IList<LessonDetailsDto> GetLessonsDynamic(double? minimalLectorRating = null)
		{
			LessonDetailsDto dto = null;
			Lesson lesson = null;
			Lector lector = null;
			Review review = null;
			Course course = null;


			var join = _session
				.QueryOver(() => lesson)
				.JoinAlias(() => lesson.Lector, () => lector)
				.JoinAlias(() => lesson.Course, () => course)
				.JoinAlias(() => lesson.Reviews, () => review, JoinType.LeftOuterJoin);

			if(minimalLectorRating.HasValue)
			{
				//lectors with rating greater than lectorRating
				var subquery = QueryOver
					.Of(() => review)
					.SelectList(list => list
						.SelectGroup(() => review.Reviewable.Id))
					.Where(Restrictions.Gt(Avg(() => review.Rating), minimalLectorRating));

				join = join
					.WithSubquery
					.WhereProperty(() => lector.LectorReviewInfo.Id)
					.In(subquery);
			}

			var query = 
				join
				.SelectList(list => list
					.SelectGroup(() => lector.FirstName)
						.WithAlias(() => dto.LectorFirstName)
					.SelectGroup(() => lector.LastName)
						.WithAlias(() => dto.LectorLastName)
					.SelectGroup(() => course.Name)
						.WithAlias(() => dto.CourseName)
					.SelectAvg(() => review.Rating)
						.WithAlias(() => dto.LessonRating))
				.TransformUsing(Transformers.AliasToBean<LessonDetailsDto>())
				.List<LessonDetailsDto>();
			return query;
		}


		public IList<LessonDetailsDto> GetLessons() => GetLessonsDynamic(null);
	}
}
