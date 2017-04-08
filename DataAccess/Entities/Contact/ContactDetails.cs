using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Entities.Contact
{
    [Table("ContactDetails", Schema = "Contact")]
    public class ContactDetails
    {
        [Key]
        public int Id { get; set; }

        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
    }
}