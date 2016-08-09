using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using UniRev.Domain.Mappings;

namespace UniRev.Infrastructure
{
	public static class NHibernateConfiguration
	{
		public static ISessionFactory Configure()
		{
			NHibernateProfiler.Initialize();

			FluentConfiguration configuration = Fluently
				.Configure()
				.Database(MsSqlConfiguration.MsSql2012
											.ConnectionString(x => x.Database("NUniRev")
																	.Server(@"MDDSK40096\SQLEXPRESS")
																	.TrustedConnection()))
				.Mappings(x => {
					var assembly = typeof(EntityMap<>).Assembly;
					x.FluentMappings.AddFromAssembly(assembly);
					x.FluentMappings.Conventions.AddAssembly(assembly);
					x.HbmMappings.AddFromAssembly(assembly);
				})
				.ExposeConfiguration(x => new SchemaUpdate(x).Execute(false, true));

			return configuration.BuildSessionFactory();
		}
	}
}
