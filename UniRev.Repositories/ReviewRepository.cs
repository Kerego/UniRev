﻿using NHibernate;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;

namespace UniRev.Repositories
{
	public class ReviewRepository : Repository<Review>, IReviewRepository
	{
		public ReviewRepository(ISession session) : base(session)
		{
		}
	}
}
