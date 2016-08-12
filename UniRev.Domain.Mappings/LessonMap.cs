using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class LessonMap : SubclassMap<Lesson>
	{
		public LessonMap()
		{
			Table("Lessons");
			References(x => x.Lector).Not.Nullable();
			References(x => x.Course).Not.Nullable();
			HasMany(x => x.Schedules).Cascade.SaveUpdate().ForeignKeyCascadeOnDelete().Inverse();
		}
	}
}
