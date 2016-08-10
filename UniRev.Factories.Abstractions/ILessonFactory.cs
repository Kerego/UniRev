using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Domain.Models;
using UniRev.Factories.Abstractions.Builders;

namespace UniRev.Factories.Abstractions
{
	public interface ILessonFactory
	{
		ILessonOptionBuilder CreateLesson(Lector lector, Course course);
	}
}
