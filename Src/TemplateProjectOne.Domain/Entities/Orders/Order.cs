using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Domain.Entities.Common;
using TemplateProjectOne.Domain.Entities.Fainance;
using TemplateProjectOne.Domain.Entities.Product;
using TemplateProjectOne.Domain.Entities.Users;

namespace TemplateProjectOne.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public RequestPay RequestPay { get; set; }
        public int RequestPayId { get; set; }
        public string Address { get; set; }
        public OrderState OrderState { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail : BaseEntity
    {
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public virtual AddProduct Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }

    public enum OrderState
    {
        Processing = 0,
        Canceled = 1,
        Delivered = 2,
    }
}
