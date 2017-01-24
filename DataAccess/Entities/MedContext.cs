using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.Entities.Mapping;

namespace DataAccess.Entities
{
    public class MedContext : DbContext
    {
        public MedContext()
            : base("name=MedContext")
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}