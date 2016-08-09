using NHibernate;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;

namespace UniRev.Repositories
{
	internal class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(ISession session) : base(session) { }

		public void ChangePassword(long id, string newPassword)
		{
			var user = _session.Get<User>(id);
			user?.SetPassword(newPassword);
		}
	}
}
