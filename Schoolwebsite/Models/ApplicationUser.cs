using Microsoft.AspNetCore.Identity;

namespace Schoolwebsite.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
