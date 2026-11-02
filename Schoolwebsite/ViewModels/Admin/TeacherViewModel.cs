using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.ViewModels.Admin
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the teacher's name.")]
        [StringLength(150)]
        [Display(Name = "Full name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter their role.")]
        [StringLength(150)]
        [Display(Name = "Role / Title")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the subject they teach.")]
        [StringLength(150)]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please write a short bio.")]
        [Display(Name = "About")]
        public string About { get; set; } = string.Empty;

        [Display(Name = "Achievements")]
        public string? Achievements { get; set; }

        [Display(Name = "Teaching objective")]
        public string? Objective { get; set; }

        [Display(Name = "Facebook URL")]
        public string? FacebookUrl { get; set; } = "#";

        [Display(Name = "Twitter URL")]
        public string? TwitterUrl { get; set; } = "#";

        [Display(Name = "LinkedIn URL")]
        public string? LinkedInUrl { get; set; } = "#";

        [Display(Name ="Administration")]
        public bool IsAdministration { get; set; }

        [Display(Name = "Head of Department (HOD)")]
        public bool IsHod { get; set; }

        [Display(Name ="House Master")]
        public bool IsHouseMaster { get; set; }

        [Display(Name="Teacher")]
        public bool IsTeacher { get; set; }

        [Display(Name = "Photo")]

        public IFormFile? Image { get; set; }
        [Display(Name = "Administration title (e.g. Vice Principal)")]
        public string? AdministrationTitle { get; set; }

        [Display(Name = "HOD title (e.g. Head of Science Department)")]
        public string? HodTitle { get; set; }

        [Display(Name = "House Master title (e.g. Master, Blue House)")]
        public string? HouseMasterTitle { get; set; }

       

        // Populated on Edit so the form/controller knows there's already an
        // image if the admin doesn't choose a new file.
        public string? ExistingImagePath { get; set; }


    }
}
