using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Domain.Models;

namespace UniRev.Domain.Mappings
{
	public class ScheduleMap : EntityMap<Schedule>
	{
		public ScheduleMap()
		{
			Table("Schedules");
			Map(x => x.Time).Not.Nullable();
			Map(x => x.Day).Not.Nullable();
			Map(x => x.Address).Not.Nullable();
			References(x => x.Lesson).Not.Nullable();
		}
	}
}
