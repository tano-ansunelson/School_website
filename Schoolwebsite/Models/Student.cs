using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.Models
{
    public class Student
    {
        public int StudentId {  get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Role {  get; set; } = string.Empty;


        [Required, StringLength(300)]
        public string ImagePath { get; set; } = string.Empty;

    }
}
