using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.ViewModels.Admin
{
    public class BlogPostViewModel
    {
      public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the author's name.")]
        [StringLength(150)]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please choose a date.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Please enter a category.")]
        [StringLength(100)]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please write a short summary.")]
        [StringLength(500)]
        public string Summary { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please write the post content.")]
        [Display(Name = "Content (one paragraph per line)")]
        public string Body { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public IFormFile? Image { get; set; }

        public string? ExistingImagePath { get; set; }
    }
}
