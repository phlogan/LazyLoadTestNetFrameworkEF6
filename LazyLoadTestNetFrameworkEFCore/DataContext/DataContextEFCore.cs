using LazyLoadTestNetFrameworkEFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LazyLoadTestNetFrameworkEFCore.DataContext
{
    public class DataContextEFCore : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mudando o comportamento para não deletar em Cascate
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<School>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Course>().HasKey(s => s.Id);
            modelBuilder.Entity<Enrollment>().HasKey(s => s.Id);
            modelBuilder.Entity<Teacher>().HasKey(s => s.Id);
            modelBuilder.Entity<Grade>().HasKey(s => s.Id);

            // Configure relationships as needed (similar to EF6, but using EF Core syntax)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.School)
                .WithMany(sch => sch.Students)
                .HasForeignKey(s => s.SchoolId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=$YOURDATASOURCE;Database=LazyLoadTestNetFrameworkEF6;Trusted_Connection=True;TrustServerCertificate=True;User ID=sa;Password=sa$so11SA");
            
        }
        public DataContextEFCore()
        {

        }
    }

}
