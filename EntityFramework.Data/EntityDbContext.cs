using EntityFramework.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions options): base(options) 
        {
            
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable(nameof(Company)).HasKey(x => x.Id);
            modelBuilder.Entity<Employee>().ToTable(nameof(Employee)).HasKey(x => x.Id);

            modelBuilder.Entity<Company>()
                .HasMany<Employee>(e => e.Employees);

            modelBuilder.Entity<Employee>()              
                .HasOne<Company>(c => c.Company);
        }

    }
}
