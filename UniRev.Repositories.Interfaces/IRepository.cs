using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UniRev.Domain.Models;

namespace UniRev.Repositories.Interfaces
{
	public interface IRepository<T> : IDisposable where T : Entity 
	{
		TK GetById<TK>(long id) where TK : T;
		IList<TK> Read<TK>(Expression<Func<TK, bool>> filter) where TK : T;
		IList<TK> Read<TK>() where TK : T;

		T GetById(long id);
		IList<T> Read(Expression<Func<T, bool>> filter);
		IList<T> Read();

		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}