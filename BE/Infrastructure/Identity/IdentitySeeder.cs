using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public static class IdentitySeeder
    {
        
        public static async Task SeedRolesAsync(RoleManager<IdentityRole<Guid>> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));

            if (!await roleManager.RoleExistsAsync("Customer"))
                await roleManager.CreateAsync(new IdentityRole<Guid>("Customer"));
        }

        
    }
}
