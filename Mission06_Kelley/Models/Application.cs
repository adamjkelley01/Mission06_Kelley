using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Kelley.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Range(1888,2024)]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Edited is Required")]
        public bool Edited { get; set; }
        public string? LentTo {  get; set; }
        [Required(ErrorMessage ="CopiedToPlex is Required")]
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
