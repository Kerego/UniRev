using System.Collections.Generic;
using UniRev.Domain.Dtos;
using UniRev.Domain.Models;

namespace UniRev.Repositories.Interfaces
{
	public interface ILessonRepository : IRepository<Lesson>
	{
		IList<LessonDetailsDto> GetLessonsByLectorRating(double minimalLectorRating);
		IList<LessonDetailsDto> GetLessons();
	}
}
