using System.Data.Entity.Core.Mapping;
using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities.Character;

namespace DataAccess.Entities.Mapping.Character
{
    public class NationalityMap : EntityTypeConfiguration<Nationality>
    {
        public NationalityMap()
        {
            HasKey(t => t.Id);
            ToTable("Nationality", "character");
        }
    }
}