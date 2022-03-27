using TemplateProjectOne.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Application.Interfaces.Contextes;
using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Common.Roles;
using TemplateProjectOne.Domain.Entities.Product;
using TemplateProjectOne.Domain.Entities.Product.HomePages;
using TemplateProjectOne.Domain.Entities.Product.HomePages.HomePageImages;

namespace TemplateProjectOne.Persistance.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UsersInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AddProduct> AddProducts { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Sliders> Sliders { get; set; }
        public DbSet<HomePageImages> HomePageImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Seed Data
            SeedData(modelBuilder);


            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            //-- عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(RoleList.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(RoleList.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(RoleList.Customer) });
        }


        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
        }


    }
}
