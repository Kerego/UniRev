namespace UniRev.Domain.Dtos
{
	public class NamedUserDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username => $"{FirstName} {LastName}";
		public long Id { get; set; }
	}
}
