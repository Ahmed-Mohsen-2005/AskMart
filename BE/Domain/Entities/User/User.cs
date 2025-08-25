using Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Address { get; set; } = string.Empty;
        public GenderType? Gender { get; set; }

        public UserType? Type { get; set; }
    }
}
