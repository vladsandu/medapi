using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Entities.Character
{
    [Table("InsuranceStatus", Schema = "Character")]
    public class InsuranceStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}