using System;

namespace UniRev.Domain.Models
{
	public abstract class Entity
	{
		public virtual long Id { get; protected set; }

		public static bool operator ==(Entity left, Entity right)
		{
			if (ReferenceEquals(left, right))
				return true;
			if (ReferenceEquals(left, null))
				return false;

			return left.Equals(right);
		}

		public static bool operator !=(Entity left, Entity right)
		{
			return !(left == right);
		}

		public virtual bool Equals(Entity other)
		{
			if (ReferenceEquals(other, null))
				return false;
			if (ReferenceEquals(other, this))
				return true;

			if (!IsTransient(this) && !IsTransient(other) && Equals(Id, other.Id))
			{
				Type thisType = GetUnproxiedType();
				Type otherType = other.GetUnproxiedType();

				return thisType.IsAssignableFrom(otherType) ||
					otherType.IsAssignableFrom(thisType);
			}

			return false;
		}

		private static bool IsTransient(Entity entity)
		{
			return entity != null && Equals(entity.Id, default(long));
		}

		protected virtual Type GetUnproxiedType()
		{
			return GetType();
		}

	}
}