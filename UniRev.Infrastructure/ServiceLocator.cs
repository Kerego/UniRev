﻿using NHibernate;
using Ninject;
using UniRev.Factories;
using UniRev.Factories.Abstractions;
using UniRev.Repositories;
using UniRev.Repositories.Interfaces;

namespace UniRev.Infrastructure
{
	public static class ServiceLocator
	{
		private static readonly IKernel kernel = new StandardKernel();

		public static void RegisterAll()
		{
			//factories

			kernel.Bind<ICourseFactory>().To<CourseFactory>().InSingletonScope();
			kernel.Bind<IUserFactory>().To<UserFactory>().InSingletonScope();
			kernel.Bind<IReviewFactory>().To<ReviewFactory>().InSingletonScope();
			kernel.Bind<ILessonFactory>().To<LessonFactory>().InSingletonScope();

			//nhibernate
			kernel.Bind<ISessionFactory>().ToMethod(_ => NHibernateConfiguration.Configure()).InSingletonScope();
			kernel.Bind<ISession>().ToMethod(context => context.Kernel.Get<ISessionFactory>().OpenSession()).InThreadScope();

			//repositories
			kernel.Bind<ILessonRepository>().To<LessonRepository>().InTransientScope();
			kernel.Bind<IUserRepository>().To<UserRepository>().InTransientScope();
			kernel.Bind<IReviewRepository>().To<ReviewRepository>().InTransientScope();
			kernel.Bind<ICourseRepository>().To<CourseRepository>().InTransientScope();
		}

		public static T Get<T>() where T : class => kernel.Get<T>();
	}
}
