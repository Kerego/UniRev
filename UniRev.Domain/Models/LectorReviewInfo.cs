namespace UniRev.Domain.Models
{
	public class LectorReviewInfo : Reviewable
	{
		public virtual Lector Lector { get; protected set; }
		public override string ShortDescription { get; protected internal set; }
	}
}
