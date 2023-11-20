namespace CoursesApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Sales.Buyers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Status);
            
            CreateTable(
                "Sales.CartCourses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BuyerId = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Sales.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("Sales.Buyers", t => t.BuyerId, cascadeDelete: true)
                .Index(t => new { t.BuyerId, t.CourseId }, unique: true)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "Sales.Courses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        UnitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 500, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Title, unique: true)
                .Index(t => t.Status);
            
            CreateTable(
                "Sales.CourseLessons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        OrderPosition = c.Short(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Sales.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => new { t.CourseId, t.OrderPosition }, unique: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Title, unique: true);
            
            CreateTable(
                "Sales.CourseClasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseLessonId = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        OrderPosition = c.Short(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        MediaType = c.Int(nullable: false),
                        UrlMedia = c.String(nullable: false, maxLength: 200, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Sales.CourseLessons", t => t.CourseLessonId, cascadeDelete: true)
                .Index(t => new { t.CourseLessonId, t.OrderPosition }, unique: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Title, unique: true)
                .Index(t => t.MediaType);
            
            CreateTable(
                "Sales.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BuyerId = c.Guid(nullable: false),
                        PaymentId = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Sales.Buyers", t => t.BuyerId, cascadeDelete: true)
                .Index(t => t.BuyerId)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "Sales.OrdersDetail",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Sales.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("Sales.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => new { t.OrderId, t.CourseId }, unique: true)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "Sales.Payments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        DateExecution = c.DateTime(nullable: false),
                        Method = c.Int(nullable: false),
                        Description = c.String(maxLength: 500, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Sales.Orders", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.OrderId, unique: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.DateExecution)
                .Index(t => t.Method);
            
            CreateTable(
                "Security.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Status);
            
            CreateTable(
                "Security.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Street = c.String(maxLength: 200, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        State = c.String(maxLength: 50, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        ZipCode = c.String(maxLength: 10, unicode: false),
                        Status = c.Int(nullable: false),
                        Description = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Security.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Status);
            
            CreateTable(
                "Service.StudentCourses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        CourseId = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        CourseTitle = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Service.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => new { t.StudentId, t.CourseId }, unique: true)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "Service.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Status);
            
            CreateTable(
                "Service.StudentsProgress",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentCourseId = c.Guid(nullable: false),
                        CourseLessonId = c.Guid(nullable: false),
                        CourseClassId = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 20, unicode: false),
                        Description = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Service.StudentCourses", t => t.StudentCourseId, cascadeDelete: true)
                .Index(t => new { t.StudentCourseId, t.CourseLessonId, t.CourseClassId }, unique: true)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Service.StudentsProgress", "StudentCourseId", "Service.StudentCourses");
            DropForeignKey("Service.StudentCourses", "StudentId", "Service.Students");
            DropForeignKey("Security.Users", "RoleId", "Security.Roles");
            DropForeignKey("Sales.Orders", "BuyerId", "Sales.Buyers");
            DropForeignKey("Sales.Payments", "Id", "Sales.Orders");
            DropForeignKey("Sales.OrdersDetail", "OrderId", "Sales.Orders");
            DropForeignKey("Sales.OrdersDetail", "CourseId", "Sales.Courses");
            DropForeignKey("Sales.CartCourses", "BuyerId", "Sales.Buyers");
            DropForeignKey("Sales.CartCourses", "CourseId", "Sales.Courses");
            DropForeignKey("Sales.CourseLessons", "CourseId", "Sales.Courses");
            DropForeignKey("Sales.CourseClasses", "CourseLessonId", "Sales.CourseLessons");
            DropIndex("Service.StudentsProgress", new[] { "Code" });
            DropIndex("Service.StudentsProgress", new[] { "StudentCourseId", "CourseLessonId", "CourseClassId" });
            DropIndex("Service.Students", new[] { "Status" });
            DropIndex("Service.Students", new[] { "Code" });
            DropIndex("Service.StudentCourses", new[] { "Code" });
            DropIndex("Service.StudentCourses", new[] { "StudentId", "CourseId" });
            DropIndex("Security.Users", new[] { "Status" });
            DropIndex("Security.Users", new[] { "Code" });
            DropIndex("Security.Users", new[] { "RoleId" });
            DropIndex("Security.Roles", new[] { "Status" });
            DropIndex("Security.Roles", new[] { "Name" });
            DropIndex("Security.Roles", new[] { "Code" });
            DropIndex("Sales.Payments", new[] { "Method" });
            DropIndex("Sales.Payments", new[] { "DateExecution" });
            DropIndex("Sales.Payments", new[] { "Code" });
            DropIndex("Sales.Payments", new[] { "OrderId" });
            DropIndex("Sales.Payments", new[] { "Id" });
            DropIndex("Sales.OrdersDetail", new[] { "Code" });
            DropIndex("Sales.OrdersDetail", new[] { "OrderId", "CourseId" });
            DropIndex("Sales.Orders", new[] { "Code" });
            DropIndex("Sales.Orders", new[] { "BuyerId" });
            DropIndex("Sales.CourseClasses", new[] { "MediaType" });
            DropIndex("Sales.CourseClasses", new[] { "Title" });
            DropIndex("Sales.CourseClasses", new[] { "Code" });
            DropIndex("Sales.CourseClasses", new[] { "CourseLessonId", "OrderPosition" });
            DropIndex("Sales.CourseLessons", new[] { "Title" });
            DropIndex("Sales.CourseLessons", new[] { "Code" });
            DropIndex("Sales.CourseLessons", new[] { "CourseId", "OrderPosition" });
            DropIndex("Sales.Courses", new[] { "Status" });
            DropIndex("Sales.Courses", new[] { "Title" });
            DropIndex("Sales.Courses", new[] { "Code" });
            DropIndex("Sales.CartCourses", new[] { "Code" });
            DropIndex("Sales.CartCourses", new[] { "BuyerId", "CourseId" });
            DropIndex("Sales.Buyers", new[] { "Status" });
            DropIndex("Sales.Buyers", new[] { "Code" });
            DropTable("Service.StudentsProgress");
            DropTable("Service.Students");
            DropTable("Service.StudentCourses");
            DropTable("Security.Users");
            DropTable("Security.Roles");
            DropTable("Sales.Payments");
            DropTable("Sales.OrdersDetail");
            DropTable("Sales.Orders");
            DropTable("Sales.CourseClasses");
            DropTable("Sales.CourseLessons");
            DropTable("Sales.Courses");
            DropTable("Sales.CartCourses");
            DropTable("Sales.Buyers");
        }
    }
}
