using Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Address { get; set; } 
        public GenderType? Gender {get; set;}

        public UserType? Type { get; set; }
    }
}
