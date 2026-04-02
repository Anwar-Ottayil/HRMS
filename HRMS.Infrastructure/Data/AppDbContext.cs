using HRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.MonthlySalary)
                      .HasPrecision(18, 2)
                      .IsRequired();
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(a => a.Date)
                      .IsRequired();

                entity.Property(a => a.Status)
                      .IsRequired();

                entity.HasOne(a => a.Employee)
                      .WithMany(e => e.Attendances)
                      .HasForeignKey(a => a.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(a => new { a.EmployeeId, a.Date })
                      .IsUnique();
            });
        }
    }
}

