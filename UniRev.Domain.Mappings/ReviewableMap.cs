using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class ReviewableMap : EntityMap<Reviewable>
	{
		public ReviewableMap()
		{
			Table("Reviewables");
			HasMany(x => x.Reviews).Cascade.SaveUpdate().ForeignKeyCascadeOnDelete().Inverse();
		}
	}
}
