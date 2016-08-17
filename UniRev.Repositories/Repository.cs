using NHibernate;
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

		public virtual void Create(T entity) =>_session.Save(entity);

		public virtual void Delete(T entity) => _session.Delete(entity);

		public virtual void Update(T entity) => _session.Update(entity);

		public T GetById(long id) => GetById<T>(id);

		public virtual TDerived GetById<TDerived>(long id) where TDerived : T 
			=> _session.Get<TDerived>(id);

		public void Dispose() => _session.Dispose();

	}
}
