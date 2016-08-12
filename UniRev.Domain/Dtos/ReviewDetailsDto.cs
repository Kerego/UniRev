
namespace UniRev.Domain.Dtos
{
	public class ReviewDetailsDto
	{
		public string ReviewerFirstName { get; set; }
		public string ReviewerLastName { get; set; }
		public string Reviewer => $"{ReviewerFirstName} {ReviewerLastName}";
		public string Reviewable { get; set; }
		public string Comment { get; set; }
		public int Rating { get; set; }
	}
}
