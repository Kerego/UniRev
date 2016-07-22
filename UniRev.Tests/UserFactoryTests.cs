using System;
using UniRev.Infrastructure;
using UniRev.Factories.Abstractions;
using Xunit;

namespace UniRev.Tests
{
	public class UserFactoryTests : IClassFixture<RegisterDependencies>
	{
		[Theory]
		[InlineData("", "")]
		[InlineData("",	"sda")]
		[InlineData("OOP", "")]
		public void TestCourseShouldNotBeCreated(string name, string password)
		{
			var factory = ServiceLocator.Get<IUserFactory>();
			Assert.Throws<ArgumentException>(() => factory.CreateStudent(name, password));
		}

	}
}
