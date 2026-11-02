using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.ViewModels.Admin
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the event title.")]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please choose a date.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Please enter a start time.")]
        [StringLength(50)]
        [Display(Name = "Start time (e.g. 9:00 AM)")]
        public string StartTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an end time.")]
        [StringLength(50)]
        [Display(Name = "End time (e.g. 1:00 PM)")]
        public string EndTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a location.")]
        [StringLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please write a short summary.")]
        [StringLength(500)]
        public string Summary { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please write the event details.")]
        [Display(Name = "Details (one paragraph per line)")]
        public string Body { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public IFormFile? Image { get; set; }

        public string? ExistingImagePath { get; set; }


    }
}
