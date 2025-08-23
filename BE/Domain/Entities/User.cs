using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        // For password reset functionality
        public string? ResetPasswordToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
    }
}
