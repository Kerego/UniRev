using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UniRev.Domain.Models;

namespace UniRev.Repositories.Interfaces
{
	public interface IRepository<T> : IDisposable where T : Entity 
	{
		T GetById(long id);
		IEnumerable<T> Read(Expression<Func<T, bool>> filter);
		IEnumerable<T> Read();
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}