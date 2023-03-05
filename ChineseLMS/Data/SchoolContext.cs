using ChineseLMS.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseLMS.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<SchoolAssignment> SchoolAssignments { get; set; }

        public DbSet<Module> Modules { get; set; }
        public DbSet<ResourceFile> ResourceFiles { get; set; }
        public DbSet<CourseMessage> CourseMessages { get; set; }
        public DbSet<CourseTimeBlock> CourseTimeBlocks { get; set; }
        public DbSet<TimeBlock> TimeBlocks { get; set; }
        public DbSet<Todo> Todos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors)
                .WithMany(i => i.Courses);
            modelBuilder.Entity<Course>()
                .HasMany(i => i.ResourceFiles);
            modelBuilder.Entity<Course>()
                .HasMany(i => i.CourseTimeBlocks);


            modelBuilder.Entity<Course>()
                .ToTable(nameof(Course));
            modelBuilder.Entity<Course>()
                .HasOne(m => m.Department)
                .WithMany(m => m.Courses)
                .HasForeignKey(m => m.DepartmentID);

            modelBuilder.Entity<Student>().ToTable(nameof(Student));

            modelBuilder.Entity<CourseMessage>()
                .ToTable(nameof(CourseMessage));

            modelBuilder.Entity<Instructor>()
                .ToTable(nameof(Instructor));

            modelBuilder.Entity<Department>()
                .ToTable(nameof(Department))
                .Property(d => d.ConcurrencyToken)
                .IsConcurrencyToken();

            modelBuilder.Entity<SchoolAssignment>()
                .ToTable(nameof(SchoolAssignment));

            modelBuilder.Entity<Module>()
                .ToTable(nameof(Module));

            modelBuilder.Entity<ResourceFile>()
                .ToTable(nameof(ResourceFile));

            modelBuilder.Entity<CourseTimeBlock>()
                .ToTable(nameof(CourseTimeBlock));

            modelBuilder.Entity<TimeBlock>()
                .ToTable(nameof(TimeBlock))
                .HasKey(b => b.TimeBlockID);

            modelBuilder.Entity<Todo>()
                .HasOne(m => m.SchoolAssignment)
                .WithMany(m => m.Todos)
                .HasForeignKey(m => m.SchoolAssignmentID);
        }
    }
}