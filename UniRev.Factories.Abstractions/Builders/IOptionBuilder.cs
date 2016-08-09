using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniRev.Factories.Abstractions.Builders
{
	public interface IOptionBuilder<out T>
	{
		T Complete();
	}
}
