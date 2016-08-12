using FluentNHibernate.Mapping;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class LectorMap : SubclassMap<Lector>
	{
		public LectorMap()
		{
			Table("Lectors");
			Map(x => x.Organization);
			References(x => x.LectorReviewInfo).Cascade.SaveUpdate().Unique().Not.Nullable();
			HasMany(x => x.Lessons).Cascade.SaveUpdate().Not.KeyNullable().ForeignKeyCascadeOnDelete().Inverse();
		}
	}
}
