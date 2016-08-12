using System;
using System.Collections.Generic;

namespace UniRev.Domain.Models
{
	public abstract class User : Entity
	{
		public virtual string FirstName { get; protected set; }
		public virtual string LastName { get; protected set; }
		public virtual string Email { get; protected set; }
		public virtual string Password { get; protected set; }
		public virtual IList<Review> Reviews { get; protected internal set; }

		protected User()
		{
		}

		internal User(string firstName, string lastName, string email, string password)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			var hash = password; //hash
			Password = hash;
			Reviews = new List<Review>();
		}

		public virtual void SetPassword(string password)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentException($"{nameof(password)} is empty", nameof(password));
			Password = password;
		}
	}
}