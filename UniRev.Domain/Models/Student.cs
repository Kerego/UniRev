namespace UniRev.Domain.Models
{
	public class Student : User
	{
		public virtual string AlmaMater { get; protected internal set; }
		internal Student(string firstName, string lastName, string email, string password) : base(firstName, lastName , email, password)
		{
		}

		protected Student()
		{
			
		}
	}

}