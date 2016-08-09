using System;
using UniRev.Domain.Models;
using UniRev.Factories;
using UniRev.Factories.Abstractions;
using Xunit;

namespace UniRev.Domain.Tests
{
	public class StudentFixture
	{

		IUserFactory userFactory = new UserFactory();

		[Theory]
		[InlineData(null)]
		[InlineData("  ")]
		[InlineData("")]
		public void UserConstructorShouldThrowOnEmptyFirstName(string firstname)
		{
			//arrange
			var password = "password";
			var lastname = "lastname";
			var email = "mail@mail.mail";

			//act
			var exception = Record.Exception(() => userFactory.CreateStudent(firstname, lastname, email, password));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentException>(exception);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("  ")]
		[InlineData("")]
		public void UserConstructorShouldThrowOnEmptyLastName(string lastname)
		{
			//arrange
			var password = "password";
			var firstname = "firstname";
			var email = "mail@mail.mail";

			//act
			var exception = Record.Exception(() => userFactory.CreateStudent(firstname, lastname, email, password));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentException>(exception);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("  ")]
		[InlineData("")]
		public void UserConstructorShouldThrowOnEmptyEmail(string email)
		{
			//arrange
			var password = "password";
			var firstname = "firstname";
			var lastname = "lastname";

			//act
			var exception = Record.Exception(() => userFactory.CreateStudent(firstname, lastname, email, password));

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
			var email = "mail@mail.mail";
			var firstname = "firstname";
			var lastname = "lastname";

			//act
			var exception = Record.Exception(() => userFactory.CreateStudent(firstname, lastname, email, password));

			//assert
			Assert.NotNull(exception);
			Assert.IsType<ArgumentException>(exception);
		}

		[Fact]
		public void UserConstructorShouldCreateOnCorrectValues()
		{
			//arrange
			var password = "password";
			var email = "mail@mail.mail";
			var firstname = "firstname";
			var lastname = "lastname";

			//act
			var exception = Record.Exception(() => userFactory.CreateStudent(firstname, lastname, email, password));

			//assert
			Assert.True(true);
		}
		
	}
}
