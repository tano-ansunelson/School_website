using System.ComponentModel.DataAnnotations;

namespace Schoolwebsite.Models
{
    public class ContactFormModel
    {

        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Your name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a valid email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please leave us a message.")]
        [Display(Name = "Message")]
        public string Message { get; set; } = string.Empty;
    }
}
