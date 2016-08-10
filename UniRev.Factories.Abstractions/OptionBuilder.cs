namespace UniRev.Factories.Abstractions
{
	public abstract class OptionBuilder<T>
	{
		protected T Entity { get; }

		protected OptionBuilder(T entity)
		{
			Entity = entity;
		}

		public virtual T Complete()
		{
			return Entity;
		}
	}
}