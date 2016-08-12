using System.Collections;
using System.Collections.Generic;
using UniRev.Domain.Dtos;
using UniRev.Domain.Models;

namespace UniRev.Repositories.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		void ChangePassword(long id, string newPassword);

		IList<UserReviewsDetailsDto> GetUserReviewStats();

		IList<Lector> GetBestTeacherForCourse(long courseId);
	}
}
