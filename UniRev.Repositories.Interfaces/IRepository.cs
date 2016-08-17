using System;
using UniRev.Domain.Models;

namespace UniRev.Repositories.Interfaces
{
	public interface IRepository<T> : IDisposable where T : Entity 
	{
		TDerived GetById<TDerived>(long id) where TDerived : T;
		T GetById(long id);
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}