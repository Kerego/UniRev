namespace UniRev.Domain.Dtos
{
	public class UserReviewsDetailsDto
	{
		public long UserId { get; set; }
		public string Username { get; set; }
		public int ReviewsCount { get; set; }
		public double AverageRating { get; set; }
	}
}
