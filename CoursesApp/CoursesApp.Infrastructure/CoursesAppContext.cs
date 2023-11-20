using Common.Model;
using CoursesApp.Domain.Sales.BuyerAggregate;
using CoursesApp.Domain.Sales.CourseAggregate;
using CoursesApp.Domain.Security.RoleAggregate;
using CoursesApp.Domain.Service.StudentAggregate;
using CoursesApp.Infrastructure.Sales.BuyerInfrastructure;
using CoursesApp.Infrastructure.Sales.CourseInfrastructure;
using CoursesApp.Infrastructure.Security.RoleInfrastructure;
using CoursesApp.Infrastructure.Service.StudentInfrastructure;
using System.Data.Entity;

namespace CoursesApp.Infrastructure
{
    public class CoursesAppContext : DbContext, IDbContext
    {
        public CoursesAppContext()
            : base(ConfigurationManager.AppSettings["ConnectionStrings:mssql"])
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        // Role

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        // Course

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseLesson> CourseLessons { get; set; }
        public virtual DbSet<CourseClass> CourseClasses { get; set; }

        // Buyer

        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<CartCourse> CartCourses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrdersDetail { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        // Student

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<StudentProgress> StudentsProgress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            // Role
            new RoleConfiguration(modelBuilder);
            new UserConfiguration(modelBuilder);

            // Course
            new CourseConfiguration(modelBuilder);
            new CourseLessonConfiguration(modelBuilder);
            new CourseClassConfiguration(modelBuilder);

            // Buyer
            new BuyerConfiguration(modelBuilder);
            new CartCourseConfiguration(modelBuilder);
            new OrderConfiguration(modelBuilder);
            new OrderDetailConfiguration(modelBuilder);
            new PaymentConfiguration(modelBuilder);

            // Student
            new StudentConfiguration(modelBuilder);
            new StudentCourseConfiguration(modelBuilder);
            new StudentProgressConfiguration(modelBuilder);
        }
    }
}
