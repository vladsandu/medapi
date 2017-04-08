using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Entities.Contact
{
    [Table("City", Schema = "Contact")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}