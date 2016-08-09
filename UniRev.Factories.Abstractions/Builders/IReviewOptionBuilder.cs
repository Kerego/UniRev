using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRev.Domain.Models;

namespace UniRev.Factories.Abstractions.Builders
{
	public interface IReviewOptionBuilder : IOptionBuilder<Review>
	{
		IReviewOptionBuilder WithAnonymous(bool isAnonymous);

		IReviewOptionBuilder WithComment(string comment);
	}
}
