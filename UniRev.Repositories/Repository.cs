using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UniRev.Domain.Models;

namespace UniRev.Repositories.Interfaces
{
	public abstract class Repository<T> : IRepository<T> where T : Entity
	{
		protected readonly ISession _session;
		public Repository(ISession session)
		{
			_session = session;
		}

		public void Create(T entity)
		{
			using (var transaction = _session.BeginTransaction())
			{
				_session.Save(entity);
				transaction.Commit();
			}
		}

		public void Delete(T entity)
		{
			using (var transaction = _session.BeginTransaction())
			{
				_session.Delete(entity);
				transaction.Commit();
			}
		}

		public void Dispose() =>_session.Dispose();

		public T GetById(long id) => _session.Get<T>(id);

		public IEnumerable<T> Read() => _session.QueryOver<T>().List();

		public IEnumerable<T> Read(Expression<Func<T, bool>> filter)
		{
			return _session.QueryOver<T>().Where(filter).List();
		}

		public void Update(T entity)
		{
			using (var transaction = _session.BeginTransaction())
			{
				_session.Update(entity);
				transaction.Commit();
			}
		}
	}
}
