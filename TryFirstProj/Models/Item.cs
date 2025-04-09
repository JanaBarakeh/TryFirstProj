using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryFirstProj.Models
{
    public class Item
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        [DisplayName("The Price")]
        [Range(10, 1000, ErrorMessage = "Price must be between 10 and 1000")]
        public decimal price { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;

        [Required]
        [DisplayName("Catogrey")]
        [ForeignKey("catogrey")]
        public int catogreyId { get; set; }

        public Catogrey? catogrey { get; set; }

    }
}
