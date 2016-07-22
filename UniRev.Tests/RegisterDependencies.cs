using UniRev.Infrastructure;

namespace UniRev.Tests
{
	internal class RegisterDependencies
	{
		public RegisterDependencies()
		{
			ServiceLocator.RegisterAll();
		}
	}
}
