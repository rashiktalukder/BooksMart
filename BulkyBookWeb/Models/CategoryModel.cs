using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display order must be between 1 to 100 Only!!")]
        public string DisplayOrder { get; set; }
        //public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
    }
}
