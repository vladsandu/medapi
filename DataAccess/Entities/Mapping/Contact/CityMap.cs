using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities.Contact;

namespace DataAccess.Entities.Mapping.Contact
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            HasKey(t => t.Id);
            ToTable("City", "contact");
        }
    }
}