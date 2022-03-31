using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Domain.Entities.Common;
using TemplateProjectOne.Domain.Entities.Users;
using TemplateProjectOne.Domain.Entities.Product;

namespace TemplateProjectOne.Domain.Entities.Carts
{
    public class Cart:BaseEntity
    {
        public virtual User User { get; set; }

        //The reason it is taken as a non-label is that a shopping cart can
        //be created without the user logging in.
        public int? UserId { get; set; }

        //It saves a specific code for each browser in the database for when
        //the user has not logged in but has created a shopping cart, and
        //this makes it possible to assign the shopping cart to the desired
        //user after logging in.
        public Guid BrowserId { get; set; }

        //If the user performs the settlement operation in the shopping cart,
        //it means the end of the shopping cart, and this boolean can become
        //a true.
        public bool Finished { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }

    public class CartItem : BaseEntity
    {
        public virtual AddProduct Product{ get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public virtual Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}
