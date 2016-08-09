using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace UniRev.Domain.Mappings.Conventions
{
	public class KeyNameConvention : IReferenceConvention, IHasManyConvention
	{
		public void Apply(IManyToOneInstance instance)
		{
			instance.ForeignKey($"FK_{instance.Class.Name}_{instance.Property?.Name}_Id");
		}

		public void Apply(IOneToManyCollectionInstance instance)
		{
			instance.Key.ForeignKey($"FK_{instance.ChildType.Name}_{instance.EntityType.Name}_Id");
		}

	}
}
