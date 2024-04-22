// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Persistence.Seed
{
    public class ForumSeed
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRoles(roleManager).ConfigureAwait(false);
            await SeedAdmin(userManager).ConfigureAwait(false);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("User").ConfigureAwait(false))
            {
                var user = new IdentityRole("User");
                await roleManager.CreateAsync(user).ConfigureAwait(false);
            }

            if (!await roleManager.RoleExistsAsync("Admin").ConfigureAwait(false))
            {
                var admin = new IdentityRole("Admin");
                await roleManager.CreateAsync(admin).ConfigureAwait(false);
            }
        }

        private static async Task SeedAdmin(UserManager<User> userManager)
        {
            var admin = new User
            {
                Name = "Dea",
                LastName = "Tchkodize",
                BirthDate = DateTime.Now.AddYears(-26),
                IsBlocked = false,
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "Admin12",
                NormalizedUserName = "ADMIN12"
            };
            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(admin, "Didi12!");
            admin.PasswordHash = hashed;

            if (await userManager.FindByEmailAsync(admin.Email).ConfigureAwait(false) is null)
            {
                var result = await userManager.CreateAsync(admin).ConfigureAwait(false);
                if(result.Succeeded)
                {
                    var addedAdmin = await userManager.FindByEmailAsync(admin.Email).ConfigureAwait(false);
                    await userManager.AddToRoleAsync(addedAdmin, "Admin").ConfigureAwait(false);
                }
            }

        }
    }
}

