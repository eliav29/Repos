using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AspNetProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Put at least 4 letters")]
        [MaxLength(40)]
        [MinLength(4, ErrorMessage = "Put at least 4 letters")]
        public string? AcComment { get; set;}
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
    }
}