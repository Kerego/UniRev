using FluentNHibernate.Mapping;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class ReviewableMap : EntityMap<Reviewable>
	{
		public ReviewableMap()
		{
			Table("Reviewables");
			Map(x => x.ShortDescription).Not.Nullable();
			HasMany(x => x.Reviews).Cascade.SaveUpdate().ForeignKeyCascadeOnDelete().Inverse();
		}
	}
}
