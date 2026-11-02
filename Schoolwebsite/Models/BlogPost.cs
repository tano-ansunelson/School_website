using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.Models
{
    public class BlogPost
    {

        public int BlogPostId { get; set; }
        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string Author { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required, StringLength(100)]
        public string Category { get; set; } = string.Empty;
        [Required, StringLength(200)]
        public string ImagePath { get; set; } = string.Empty;
        [StringLength(500)]
        public string Summary { get; set; } = string.Empty;

        // Each item in the list is rendered as its own paragraph on the details page.
        [Required]
        public string Body { get; set; } =string.Empty;
    }
}
