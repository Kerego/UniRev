namespace UniRev.Domain.Contexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Credits = c.Int(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        Timestamp = c.DateTimeOffset(nullable: false, precision: 7),
                        IsAnonymous = c.Boolean(nullable: false),
                        Course_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Group = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Reviews", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Reviews", new[] { "Student_Id" });
            DropIndex("dbo.Reviews", new[] { "Course_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Reviews");
            DropTable("dbo.Courses");
        }
    }
}
