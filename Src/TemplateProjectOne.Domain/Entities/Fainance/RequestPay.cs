using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Domain.Entities.Common;
using TemplateProjectOne.Domain.Entities.Orders;
using TemplateProjectOne.Domain.Entities.Users;

namespace TemplateProjectOne.Domain.Entities.Fainance
{
    public class RequestPay:BaseEntity
    {
        public Guid Guid { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public bool isPay { get; set; }
        public DateTime? DatePay { get; set; }
        public string Authority { get; set; } = " ";
        public long RefId { get; set; } = 0;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
