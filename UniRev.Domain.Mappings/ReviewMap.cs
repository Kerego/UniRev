using System;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class ReviewMap : EntityMap<Review>
	{
		public ReviewMap()
		{
			Table("Reviews");
			Map(x => x.Rating).Not.Nullable();
			Map(x => x.IsAnonymous).Not.Nullable();
			Map(x => x.Timestamp).Not.Nullable();
			Map(x => x.Comment);
			References(x => x.Reviewable).Not.Nullable();
			References(x => x.User).Not.Nullable();
		}
	}
}
