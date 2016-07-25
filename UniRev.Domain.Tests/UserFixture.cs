using System;
using UniRev.Domain.Models;
using Xunit;

namespace UniRev.Domain.Tests
{
	public class UserFixture
	{
		[Theory]
		[InlineData(null)]
		[InlineData("  ")]
		[InlineData("")]
		public void UserConstructorShouldThrowOnEmptyName(string name)
		{
			//arrange
			var password = "password";

			//act
			var exception = Record.Exception(() => new User(name, password));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentException>(exception);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("  ")]
		[InlineData("")]
		public void UserConstructorShouldThrowOnEmptyPassword(string password)
		{
			//arrange
			var name = "name";

			//act
			var exception = Record.Exception(() => new User(name, password));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentException>(exception);
		}

		[Fact]
		public void UserConstructorShouldCreateOnCorrectValues()
		{
			//arrange
			var name = "testuser";
			var password = "password";
		
			//act
			var user = new User(name, password);

			//assert
			Assert.True(true);
		}
		
	}
}
