namespace UniRev.Domain.Mappings
{
	using Models;

	public class NamedEntityMap<TEntity> : EntityMap<TEntity> where TEntity : NamedEntity
	{
		public NamedEntityMap()
		{
			Map(x => x.Name);
		}
	}
}
