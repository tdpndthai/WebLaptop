namespace WebLaptop_Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebLaptop_Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebLaptop_Data.WebLaptopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebLaptop_Data.WebLaptopDbContext context)
        {
            //khởi tạo dữ liệu mẫu khi chạy ứng dụng
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new WebLaptopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new WebLaptopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "thai",
            //    Email = "nguyendanhthai1605@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Nguyễn Danh Thái"

            //};
            ////tạo mới manager
            //manager.Create(user, "1605");
            ////nếu role chưa tồn tại thì tạo mới 2 role admin,user
            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("nguyendanhthai1605@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

            string[] roles = new string[] { "Admin", "User" };
            foreach (string role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    context.Roles.Add(new IdentityRole(role));
                }
            }

            //create user UserName:Owner Role:Admin
            if (!context.Users.Any(u => u.UserName == "thaind"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser
                {

                    UserName = "thaind",
                    Email = "nguyendanhthai1605@gmail.com",
                    EmailConfirmed = true,
                    BirthDay = DateTime.Now,
                    PasswordHash = userManager.PasswordHasher.HashPassword("1605"),
                    FullName = "Nguyễn Danh Thái"
                    
                };
                userManager.Create(user);
                userManager.AddToRoles(user.Id, new string[] { "Admin", "User" });
                //userManager.AddToRole(user.Id, "Admin");
                //userManager.AddToRole(user.Id, "User");
            }

            context.SaveChanges();

        }
    }
}
