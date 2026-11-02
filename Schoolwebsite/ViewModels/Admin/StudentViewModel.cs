using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.ViewModels.Admin
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the student's name.")]
        [StringLength(150)]
        [Display(Name = "Full name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter their role.")]
        [StringLength(150)]
        [Display(Name = "Role")]
        public string Role { get; set; } = string.Empty;

        [Display(Name = "Photo")]

        public IFormFile? Image { get; set; }

        public string? ExistingImagePath { get; set; }

    }
}
