namespace UniRev.Domain.Contexts.Migrations
{
	using Models;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<UniRev.Domain.Contexts.UniRevContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniRevContext context)
        {
			var student = new Student("Marian", "fdsfsd");
			var student2 = new Student("Dorin", "fdsfsd");

			var course = new Course("oop", 5);

			var review = new Review(course, student, 5);

			context.Reviews.Add(review);

			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}
    }
}
