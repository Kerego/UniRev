namespace UniRev.Domain.Models
{
	public abstract class NamedEntity : Entity
	{
		public virtual string Name { get; protected set; }
	}
}