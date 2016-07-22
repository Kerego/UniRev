using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniRev.Repositories.Interfaces;
using UniRev.Domain.Models;
using UniRev.Domain.Contexts;
using System.Data.Entity;

namespace UniRev.Repositories
{
	internal class ReviewRepository : IRepository<Review>, IDisposable
	{
		private readonly UniRevContext _context;

		public ReviewRepository(UniRevContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(Review review)
		{
			var t = _context.Reviews.Add(review);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Review review)
		{
			_context.Reviews.Remove(review);
			await _context.SaveChangesAsync();
		}

		public async Task<Review> GetByIdAsync(int id)
		{
			return await _context.Reviews.SingleOrDefaultAsync(x => x.Id == id);
		}

		public IEnumerable<Review> Read()
		{
			return _context.Reviews;
		}

		public async Task UpdateAsync(Review review)
		{
			var dbEntry = _context.Reviews.Find(review.Id);
			_context.Entry(dbEntry).CurrentValues.SetValues(review);
			await _context.SaveChangesAsync();
		}
		
		public void Dispose()
		{
			_context.Dispose();
		}

	}
}