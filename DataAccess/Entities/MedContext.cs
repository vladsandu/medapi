using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.Entities.Character;
using DataAccess.Entities.Contact;
using DataAccess.Entities.Mapping;
using DataAccess.Entities.Mapping.Character;
using DataAccess.Entities.Diagnosis;
using DataAccess.Entities.Center;

namespace DataAccess.Entities
{
    public class MedContext : DbContext
    {
        public MedContext()
            : base("name=MedContext")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<InsuranceStatus> InsuranceStatuses { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Condition> Conditions { get; set; }
        public DbSet<ConditionCategory> ConditionCategories { get; set; }
        public DbSet<Diagnosis.Diagnosis> Diagnoses { get; set; }
        public DbSet<DiagnosisType> Types { get; set; }

        public DbSet<CenterType> CenterTypes { get; set; }
        public DbSet<MedicalCenter> MedicalCenters { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}