using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLaptop_Model.Models;

namespace WebLaptop_Data
{
    public class WebLaptopDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebLaptopDbContext() : base("WebLaptop")
        {
            this.Configuration.LazyLoadingEnabled = false; //load bảng cha không tự động include bảng con
        }

        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public static WebLaptopDbContext Create()
        {
            return new WebLaptopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}
