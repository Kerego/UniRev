using FluentNHibernate.Mapping;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
	{
		public EntityMap()
		{
			Id(x => x.Id).GeneratedBy.Identity();

			DynamicUpdate();
		}
    }
}
