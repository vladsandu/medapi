using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.Entities.Character;
using DataAccess.Entities.Contact;
using DataAccess.Entities.Mapping;
using DataAccess.Entities.Mapping.Character;
using DataAccess.Entities.Diagnosis;
using DataAccess.Entities.Center;
using DataAccess.Entities.Staff;

namespace DataAccess.Entities
{
    public class MedContext : DbContext
    {
        public MedContext()
            : base("name=MedContext")
        {
        }

        //Character
        public DbSet<Person> Persons { get; set; }
        public DbSet<InsuranceStatus> InsuranceStatuses { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Patient> Patients { get; set; }

        //Contact
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<City> Cities { get; set; }

        //Diagnosis
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<ConditionCategory> ConditionCategories { get; set; }
        public DbSet<Diagnosis.Diagnosis> Diagnoses { get; set; }
        public DbSet<DiagnosisType> Types { get; set; }

        //Center
        public DbSet<CenterType> CenterTypes { get; set; }
        public DbSet<MedicalCenter> MedicalCenters { get; set; }

        //Staff
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<MedicalField> MedicalFields { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<PhysicianGrade> PhysicianGrades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}