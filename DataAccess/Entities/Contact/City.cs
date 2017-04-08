using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Entities.Contact
{
    [Table("City", Schema = "Contact")]
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}