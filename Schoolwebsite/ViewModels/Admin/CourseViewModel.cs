using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.ViewModels.Admin
{
    public class CourseViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the programme title.")]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Please enter a category.")]
        //[StringLength(100)]
        //[Display(Name = "Category (e.g. Science Track)")]
        //public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a duration.")]
        [StringLength(50)]
        [Display(Name = "Duration (e.g. 3 Years)")]
        public string Duration { get; set; } = string.Empty;

      //[Required(ErrorMessage = "Please choose a coordinating teacher.")]
       //Display(Name = "Coordinator")]
       //ublic int CoordinatorId { get; set; }

        [Required(ErrorMessage = "Please write an overview.")]
        [Display(Name = "Overview (one paragraph per line)")]
        public string Overview { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please list at least one core subject.")]
        [Display(Name = "Core subjects (one per line)")]
        public string CoreSubjects { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please list at least one elective subject.")]
        [Display(Name = "Elective subjects (one per line)")]
        public string ElectiveSubjects { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please list at least one entry requirement.")]
        [Display(Name = "Entry requirements (one per line)")]
        public string EntryRequirements { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public IFormFile? Image { get; set; }

        public string? ExistingImagePath { get; set; }

        // Populated by the controller so the Coordinator <select> has options.
        public List<Models.Teacher> AvailableTeachers { get; set; } = new();
    }
}
