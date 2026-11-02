using Microsoft.Extensions.Options;
using Schoolwebsite.Helpers;
using Schoolwebsite.Models;

namespace Schoolwebsite.Services
{
    public interface IAdminAuthService
    {
        bool ValidateCredential(string username, string password);
    }


    public class AdminAuthService: IAdminAuthService
    {
        private readonly AdminUserOptions _adminUser;

        public AdminAuthService(IOptions<AdminUserOptions> adminUser) {
        
        _adminUser = adminUser.Value;
        
        }

        public bool ValidateCredential(string username, string password) {

            if (!string.Equals(username, _adminUser.Username, StringComparison.OrdinalIgnoreCase)) {

                return false;
            }
            return PasswordHasher.Verify(password, _adminUser.PasswordHash);
        }

    }
}
