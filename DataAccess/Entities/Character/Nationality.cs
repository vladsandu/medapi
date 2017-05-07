using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Entities.Character
{
    [Table("Nationality", Schema = "Character")]
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}