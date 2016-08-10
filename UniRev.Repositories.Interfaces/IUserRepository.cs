using UniRev.Domain.Models;

namespace UniRev.Repositories.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		void ChangePassword(long id, string newPassword);
	}
}
