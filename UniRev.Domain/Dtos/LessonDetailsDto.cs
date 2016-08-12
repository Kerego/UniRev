namespace UniRev.Domain.Dtos
{
	public class LessonDetailsDto
	{
		public string LectorFirstName { get; set; }
		public string LectorLastName { get; set; }
		public string LectorName => $"{LectorFirstName} {LectorLastName}";
		public string CourseName { get; set; }
		public double Rating { get; set; }
	}
}
