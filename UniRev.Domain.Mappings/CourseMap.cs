using FluentNHibernate.Mapping;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class CourseMap : SubclassMap<Course>
	{
		public CourseMap()
		{
			Table("Courses");
			Map(x => x.Credits).Not.Nullable();
			Map(x => x.Name).Not.Nullable();
			Map(x => x.Duration);
			Map(x => x.Description);
			HasMany(x => x.Lessons).Cascade.SaveUpdate().Not.KeyNullable().ForeignKeyCascadeOnDelete().Inverse();
		}
	}
}
