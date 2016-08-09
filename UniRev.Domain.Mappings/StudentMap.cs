using FluentNHibernate.Mapping;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class StudentMap : SubclassMap<Student>
	{
		public StudentMap()
		{
			Table("Students");
			Map(x => x.AlmaMater).Not.Nullable();
		}
	}
}
