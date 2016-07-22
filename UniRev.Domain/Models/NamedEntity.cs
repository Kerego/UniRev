namespace UniRev.Domain.Models
{
	public abstract class NamedEntity : Entity
	{
		public string Name { get; protected set; }
	}
}