using Microsoft.EntityFrameworkCore;

namespace Cdv
{
    public class PeopleDatabase : DbContext
    {
        public PeopleDatabase(DbContextOptions<PeopleDatabase> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var PersonEntity = modelBuilder.Entity<PersonClass>();

            PersonEntity.ToTable("Person");
            PersonEntity.HasKey(i=>i.ID);
            PersonEntity.Property(p=>p.FirstName).HasMaxLength(50);
            PersonEntity.Property(p=>p.LastName).HasMaxLength(50);
            PersonEntity.Property(p=>p.PhoneNumber).HasMaxLength(12);
        }

        public DbSet<PersonClass> People {get; set;}
    }
}