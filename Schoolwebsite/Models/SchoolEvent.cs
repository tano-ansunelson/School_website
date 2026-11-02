using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.Models
{
    public class SchoolEvent
    {
        public int SchoolEventId { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required, StringLength(50)]
        public string StartTime { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string EndTime { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required, StringLength(300)]
        public string ImagePath { get; set; } = string.Empty;

        [Required, StringLength(500)]
        public string Summary { get; set; } = string.Empty;

        // Each line typed by the admin becomes its own paragraph on the public
        // event page — see Helpers/TextLines.cs.
        [Required]
        public string Body { get; set; } = string.Empty;


    }
}
