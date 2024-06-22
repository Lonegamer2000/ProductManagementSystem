using Microsoft.AspNetCore.Identity;
using UJJWALPMS.web.Models;

namespace UJJWALPMS.web.Data
{
    public class SeedingData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            try
            {
                var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                String[] Roles = { "ADMIN", "USER" };
                foreach (String roleName in Roles)
                {
                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                if (await _userManager.FindByNameAsync("admin@mail.com") == null)
                {
                    var role = _roleManager.FindByNameAsync("ADMIN").Result;

                    var user = new ApplicationUser()
                    {

                        FirstName = "Ujjwal",
                        LastName = "Aryal",
                        IsActive = true,
                        UserRoleId = role.Id,
                        UserName = "admin@mail.com",
                        Email = "admin@mail.com",
                        PhoneNumber = "9840503708",
                        Address = "Lolang",
                        CreatedBy = "admin",
                        CreatedDate = DateTime.Now
                    };

                    var res = await _userManager.CreateAsync(user, "@Ujjwal123");
                    await _userManager.SetLockoutEnabledAsync(user, false);
                    if (res.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "ADMIN");
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
