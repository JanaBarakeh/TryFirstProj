using System.ComponentModel.DataAnnotations;

namespace TryFirstProj.Models
{
    public class Catogrey
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        // ecah catogrey have many items
        public ICollection<Item>? Items { get; set; }
    }
}
