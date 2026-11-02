using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.Models
{
    public class Course
    {

        public int CourseId { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;
        
        //[Required, StringLength(100)]
        //public string Category { get; set; } = string.Empty; 
        
        // e.g. "Science Track"
        [Required, StringLength(100)]
        public string Duration { get; set; } = string.Empty;
        // e.g. "3 Years"
        [Required, StringLength(100)]
        public string ImagePath { get; set; } = string.Empty;
       // public int CoordinatorId { get; set; }                 // links to Teacher.Id

        [Required]
        public string Overview { get; set; } = string.Empty;
        [Required]
        public string CoreSubjects { get; set; } = string.Empty;
        [Required]
        public string ElectiveSubjects { get; set; } = string.Empty;
        [Required]
        public string EntryRequirements { get; set; } = string.Empty;
    }
}
