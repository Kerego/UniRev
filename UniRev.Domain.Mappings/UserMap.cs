using FluentNHibernate.Mapping;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class UserMap : EntityMap<User>
	{
		public UserMap()
		{
			Table("Users");
			Map(x => x.FirstName).Not.Nullable();
			Map(x => x.LastName).Not.Nullable();
			Map(x => x.Email).Not.Nullable();
			Map(x => x.Password).Not.Nullable();
			HasMany(x => x.Reviews).Cascade.SaveUpdate().ForeignKeyCascadeOnDelete().Inverse();
		}
	}
}
