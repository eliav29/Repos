using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetProject.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [DisplayName("Name:")]
        [StringLength(10)]
        [MinLength(3, ErrorMessage = "Put at least 3 letters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed")]
        public string? Name { get; set; }
        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100")]
        [DisplayName("Age:")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Upload image")]
        public string? PictureName { get; set; }
        [Required(ErrorMessage = "Put a description please.")]
        [MinLength(4, ErrorMessage = "Put at least 4 letters")]
        [DisplayName("Description:")]
        public string? Description { get; set; }
        [DisplayName("Category:")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual IEnumerable<Comment>? Comments { get; set; }
    }
}
