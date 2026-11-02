using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string Role { get; set; } = string.Empty;      // e.g. "Vice Principal", "Head of Science"

        [Required, StringLength(150)]
        public string Subject { get; set; } = string.Empty;   // e.g. "Mathematics"

        [Required, StringLength(300)]
        public string ImagePath { get; set; } = string.Empty; // relative path under wwwroot, e.g. /images/teachers/xyz.jpg

        [Required]
        public string About { get; set; } = string.Empty;

        public string? Achievements { get; set; }


        public bool IsAdministration { get; set; }
        [StringLength(150)]
        public string? AdministrationTitle { get; set; }
        public bool IsHod {  get; set; }
        [StringLength(100)]
        public string? HodTitle { get; set; }
        public bool IsHouseMaster { get; set; }
        [StringLength(100)]
        public string? HouseMasterTitle { get; set; }
        public  bool IsTeacher {  get; set; }
        public string? Objective { get; set; }

        [StringLength(300)]
        public string FacebookUrl { get; set; } = "#";

        [StringLength(300)]
        public string TwitterUrl { get; set; } = "#";

        [StringLength(300)]
        public string LinkedInUrl { get; set; } = "#";

        // Navigation: programmes this teacher coordinates.
       // public List<Course> CoordinatedCourses { get; set; } = new();
    }
}

