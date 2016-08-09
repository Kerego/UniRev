using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;

namespace UniRev.Repositories
{
	internal class HibernateReviewRepository : IRepository<Review>, IDisposable
	{
		public Task CreateAsync(Review entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Review entity)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public Task<Review> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Review> Read()
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Review entity)
		{
			throw new NotImplementedException();
		}
	}
}
