using System;

namespace UniRev.Domain.Models
{
	public class User : NamedEntity
	{
		public string Password { get; protected set; }

		protected User()
		{
		}
		public User(string name, string password)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"{nameof(name)} is empty", nameof(name));
			if(string.IsNullOrWhiteSpace(password))
				throw new ArgumentException($"{nameof(password)} is empty", nameof(password));
			Name = name;
			var hash = password; //hash
			Password = hash;
		}
	}
}