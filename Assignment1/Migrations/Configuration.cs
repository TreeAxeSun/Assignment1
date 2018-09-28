namespace Assignment1.Migrations
{
    using Assignment1.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Assignment1.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Users.Any(p => p.Email == "veris49@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "veris49@gmail.com",
                    Email = "veris49@gmail.com",
                    FirstName = "YS",
                    LastName = "Ahn",
                    NickName = "Master"
                }, "Adminuser@1");
            }

            var adminId = userManager.FindByEmail("veris49@gmail.com").Id;
            userManager.AddToRole(adminId, "Admin");
        }
    }
}
