namespace WebLaptop_Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebLaptop_Common;
    using WebLaptop_Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebLaptop_Data.WebLaptopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebLaptop_Data.WebLaptopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateSlide(context);
            CreatePage(context);
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

            //đoạn code dưới này chạy được,đoạn trên thì không(tham số truyền vào WebLaptop_Data.WebLaptopDbContext context)
            //string[] roles = new string[] { "Admin", "User" };
            //foreach (string role in roles)
            //{
            //    if (!context.Roles.Any(r => r.Name == role))
            //    {
            //        context.Roles.Add(new IdentityRole(role));
            //    }
            //}

            ////create user UserName:Owner Role:Admin
            //if (!context.Users.Any(u => u.UserName == "thaind"))
            //{
            //    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //    var user = new ApplicationUser
            //    {

            //        UserName = "thaind",
            //        Email = "nguyendanhthai1605@gmail.com",
            //        EmailConfirmed = true,
            //        BirthDay = DateTime.Now,
            //        PasswordHash = userManager.PasswordHasher.HashPassword("1605"),
            //        FullName = "Nguyễn Danh Thái"

            //    };
            //    userManager.Create(user);
            //    userManager.AddToRoles(user.Id, new string[] { "Admin", "User" });
            //    //userManager.AddToRole(user.Id, "Admin");
            //    //userManager.AddToRole(user.Id, "User");
            //}

            //context.SaveChanges();
        }
        private void CreateProductCategorySample(WebLaptop_Data.WebLaptopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory(){Name="dell latitude e6530",Alias="dell-latitude",Status=true},
                    new ProductCategory(){Name="hp elitebook 8570p",Alias="hp",Status=true},
                    new ProductCategory(){Name="lenovo thinkpad t480s",Alias="thinkpad",Status=true},
                    new ProductCategory(){Name="acer aprise s5",Alias="acer",Status=true},
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        //private void CreateFooter(WebLaptopDbContext context)
        //{
        //    if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
        //    {
        //        string content = "";
        //    }
        //}

        private void CreateSlide(WebLaptopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> slides = new List<Slide>()
                {
                    new Slide(){Name="slide1",DisplayOrder=1,Status=true,Url="#",Image="/Assets/client/images/bag.jpg",Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>"},
                    new Slide(){Name="slide2",DisplayOrder=2,Status=true,Url="#",Image="/Assets/client/images/bag1.jpg",Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>"}
                };
                context.Slides.AddRange(slides);
                context.SaveChanges();
            }
        }

        private void CreatePage(WebLaptopDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                var page = new Page()
                {
                    Name="Giới thiệu",
                    Alias="gioi-thieu",
                    Content= @"HỘ KINH DOANH NGUYỄN DANH THÁI
                                236 HOÀNG QUỐC VIỆT
                                Thành phố Hà Nội,
                                Việt Nam
                                SĐT: 0246.2544.533 - Email: contact @laptop88.vn
                                Website: laptop88.vn
                                Số ĐKKD: 0108153788, cấp lần đầu ngày
                                Sở KHĐT TP.Hà Nội cấp",
                    Status=true,
                };
                context.Pages.Add(page);
                context.SaveChanges();
            }
        }
    }
}
