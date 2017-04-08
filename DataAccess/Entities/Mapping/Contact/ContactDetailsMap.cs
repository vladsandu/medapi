using System.Data.Entity.ModelConfiguration;
using DataAccess.Entities.Contact;

namespace DataAccess.Entities.Mapping.Contact
{
    public class ContactDetailsMap : EntityTypeConfiguration<ContactDetails>
    {
        public ContactDetailsMap()
        {
            HasKey(t => t.Id);
            ToTable("ContactDetails", "contact");
        }
    }
}