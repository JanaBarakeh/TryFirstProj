using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public IFormFile clientFile { get; set; }

        public byte[]? dbImage { get; set; }

        [NotMapped]
        public string? imageSrc
        {
            get
            {
                if (dbImage != null)
                {
                    return "data:image/png;base64," + Convert.ToBase64String(dbImage,0,dbImage.Length);
                }
                return string.Empty;
            }
        }
    }
}
