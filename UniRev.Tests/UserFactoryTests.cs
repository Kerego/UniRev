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
		public void TestCreateStudentShouldThrow(string name, string password)
		{
			var factory = ServiceLocator.Get<IUserFactory>();
			Assert.Throws<ArgumentException>(() => factory.CreateStudent(name, password).Complete());
		}

		[Fact]
		public void TestCreateUserShouldBeCreated()
		{
			var factory = ServiceLocator.Get<IUserFactory>();
			var user = factory.CreateStudent("marian", "qweyrt").Complete();
			Assert.NotNull(user);
		}



	}
}
