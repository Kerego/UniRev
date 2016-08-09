using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;

namespace UniRev.Repositories
{
	public class CourseRepository : Repository<Course>, ICourseRepository
	{
		public CourseRepository(ISession session) : base(session)
		{

		}
	}
}
