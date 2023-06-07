using System.ComponentModel.DataAnnotations;

namespace AspNetProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(10)]
        public string? Name { get; set; }
        public virtual IEnumerable<Animal>? Animals { get; set; }
    }
}
