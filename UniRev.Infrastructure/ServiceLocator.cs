using Ninject;
using UniRev.Domain.Contexts;
using UniRev.Domain.Models;
using UniRev.Factories;
using UniRev.Factories.Abstractions;
using UniRev.Repositories;
using UniRev.Repositories.Interfaces;

namespace UniRev.Infrastructure
{
	public static class ServiceLocator
	{
		static readonly IKernel kernel = new StandardKernel();

		public static void RegisterAll()
		{
			kernel.Bind<ICourseFactory>().To<CourseFactory>().InSingletonScope();
			kernel.Bind<IUserFactory>().To<UserFactory>().InSingletonScope();
			kernel.Bind<IReviewFactory>().To<ReviewFactory>().InSingletonScope();
			kernel.Bind<UniRevContext>().ToSelf().InSingletonScope();
			kernel.Bind<IRepository<Review>>().To<ReviewRepository>().InSingletonScope();
		}

		public static T Get<T>() where T : class => kernel.Get<T>();
	}
}
