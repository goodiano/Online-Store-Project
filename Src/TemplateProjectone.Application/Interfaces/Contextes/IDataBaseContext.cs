using TemplateProjectOne.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Domain.Entities.Product;
using TemplateProjectOne.Domain.Entities.Product.HomePages;
using TemplateProjectOne.Domain.Entities.Product.HomePages.HomePageImages;
using TemplateProjectOne.Domain.Entities.Carts;
using TemplateProjectOne.Domain.Entities.Fainance;

namespace TemplateProjectOne.Application.Interfaces.Contextes
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserInRole> UsersInRoles { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<AddProduct> AddProducts { get; set; }
        DbSet<ProductFeature> ProductFeatures { get; set; }
        DbSet<ProductImages> ProductImages { get; set; }
        DbSet<Sliders> Sliders { get; set; }
        DbSet<HomePageImages> HomePageImages { get; set; }
        DbSet<Cart> Cart { get; set; }
        DbSet<CartItem> CartItem { get; set; }
        DbSet<RequestPay> RequestPay { get; set; }


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
