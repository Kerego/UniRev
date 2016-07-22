using System.Data.Entity;
using UniRev.Domain.Models;

namespace UniRev.Domain.Contexts
{
	internal class UniRevContext : DbContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Review> Reviews { get; set;}

	}
}