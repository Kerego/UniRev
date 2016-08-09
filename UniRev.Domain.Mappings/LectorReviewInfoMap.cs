using FluentNHibernate.Mapping;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class LectorReviewInfoMap : SubclassMap<LectorReviewInfo>
	{
		protected LectorReviewInfoMap()
		{
			Table("LectorReviewInfos");
		}
	}
}
