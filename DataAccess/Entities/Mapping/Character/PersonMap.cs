using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities.Character;

namespace DataAccess.Entities.Mapping.Character
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            HasKey(t => t.Id);
            ToTable("Person", "Character");
        }
    }
}