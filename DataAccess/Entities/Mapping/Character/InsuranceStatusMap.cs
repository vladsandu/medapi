using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities.Character;

namespace DataAccess.Entities.Mapping.Character
{
    public class InsuranceStatusMap : EntityTypeConfiguration<InsuranceStatus>
    {
        public InsuranceStatusMap()
        {
            HasKey(t => t.Id);
            ToTable("InsuranceStatus", "character");
        }
    }
}