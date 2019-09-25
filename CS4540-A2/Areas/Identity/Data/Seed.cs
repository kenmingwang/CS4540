using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CS4540_A2.Areas.Identity.Data
{
    public class Seed
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            string[] roleNames = { "Admin", "DepartmentChair", "Instructor" };
            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // TODO: Really bad place to store this hard-coded password, will fix next version.
            string password = "123ABC!@#def";

            IdentityUser Admin = new IdentityUser
            {
                UserName = "admin_erin@cs.utah.edu",
                Email = "admin_erin@cs.utah.edu"
            };

            var user = await UserManager.FindByEmailAsync(Admin.Email);

            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(Admin, password);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role 
                    await UserManager.AddToRoleAsync(Admin, "Admin");
                }
            }

            IdentityUser[] Instructors = {
                new IdentityUser
                {
                    UserName = "professor_jim@cs.utah.edu",
                    Email = "professor_jim@cs.utah.edu"
                },
                new IdentityUser
                {
                    UserName = "professor_marry@cs.utah.edu",
                    Email = "professor_marry@cs.utah.edu"
                },
                new IdentityUser
                {
                    UserName = "professor_danny@cs.utah.edu",
                    Email = "professor_danny@cs.utah.edu"
                }
            };

            foreach(IdentityUser Ins in Instructors)
            {
                var instr = await UserManager.FindByEmailAsync(Ins.Email);

                if (instr == null)
                {
                    var createPowerUser = await UserManager.CreateAsync(Ins, password);
                    if (createPowerUser.Succeeded)
                    {
                        // here we assign the new user the "Instructor" role 
                        await UserManager.AddToRoleAsync(Ins, "Instructor");
                    }
                }
            }

            IdentityUser Chair = new IdentityUser
            {
                UserName = "chair_whitaker@cs.utah.edu",
                Email = "chair_whitaker@cs.utah.edu"
            };
            user = await UserManager.FindByEmailAsync(Chair.Email);
            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(Chair, password);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role 
                    await UserManager.AddToRoleAsync(Chair, "DepartmentChair");
                }
            }

        }
    }
}
