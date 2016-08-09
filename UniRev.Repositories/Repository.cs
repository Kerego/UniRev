using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;

namespace UniRev.Repositories
{
	public abstract class Repository<T> : IRepository<T> where T : Entity
	{
		protected readonly ISession _session;

		protected Repository(ISession session)
		{
			_session = session;
		}

		public virtual void Create(T entity)
		{
			using (var transaction = _session.BeginTransaction())
			{
				_session.Save(entity);
				transaction.Commit();
			}
		}

		public virtual void Delete(T entity)
		{
			using (var transaction = _session.BeginTransaction())
			{
				_session.Delete(entity);
				transaction.Commit();
			}
		}

		public void Dispose() =>_session.Dispose();

		public virtual T GetById(long id) => _session.Get<T>(id);

		public virtual IEnumerable<T> Read() => _session.QueryOver<T>().List();

		public virtual IEnumerable<T> Read(Expression<Func<T, bool>> filter)
		{
			return _session.QueryOver<T>().Where(filter).List();
		}

		public virtual void Update(T entity)
		{
			using (var transaction = _session.BeginTransaction())
			{
				_session.Update(entity);
				transaction.Commit();
			}
		}
	}
}
