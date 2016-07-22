using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Domain.Models;

namespace UniRev.Factories.Abstractions
{
	public interface IReviewOptionBuilder
	{
		Review Complete();
		IReviewOptionBuilder WithComment(string comment);
		IReviewOptionBuilder WithAnonymous(bool anonymous);
	}
}
