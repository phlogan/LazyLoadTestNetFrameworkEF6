using LazyLoadTestNetFrameworkEF6.Entities;
using System.Data.Entity;

namespace LazyLoadTestNetFrameworkEF6.DataContext
{
    public class DataContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<School>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Course>().HasKey(s => s.Id);
            modelBuilder.Entity<Enrollment>().HasKey(s => s.Id);
            modelBuilder.Entity<Teacher>().HasKey(s => s.Id);
            modelBuilder.Entity<Grade>().HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
                .HasRequired(s => s.School)
                .WithMany(sch => sch.Students)
                .HasForeignKey(s => s.SchoolId);

            modelBuilder.Entity<Student>()
                .HasRequired(s => s.School)
                .WithMany(sch => sch.Students)
                .HasForeignKey(s => s.SchoolId)
                .WillCascadeOnDelete(false);
        }
        public DataContext() : base("Data Source=$YOURDATASOURCE;Initial Catalog=LazyLoadTestNetFrameworkEF6;Persist Security Info=False;User ID=sa;Password=sa$so11SA;TrustServerCertificate=Yes;Encrypt=False")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
    }
}
