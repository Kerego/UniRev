using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;

namespace UniRev.Repositories
{
	internal class NUserRepository : Repository<User>, IUserRepository
	{
		public NUserRepository(ISession session) : base(session) { }

		public void ChangePassword(long id, string newPassword)
		{
			var user = _session.Get<User>(id);
			if (user != null)
				user.SetPassword(newPassword);
		}

		
	}
}
