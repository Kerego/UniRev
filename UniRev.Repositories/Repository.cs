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

		public T GetById(long id) => GetById<T>(id);

		public virtual TK GetById<TK>(long id) where TK : T => _session.Get<TK>(id);

		public IList<T> Read() => Read<T>();

		public IList<T> Read(Expression<Func<T, bool>> filter) => Read<T>(filter);

		public virtual IList<TK> Read<TK>() where TK : T => _session.QueryOver<TK>().List();

		public virtual IList<TK> Read<TK>(Expression<Func<TK, bool>> filter) where TK : T
		{
			return _session.QueryOver<TK>().Where(filter).List();
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
