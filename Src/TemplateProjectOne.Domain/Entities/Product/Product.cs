using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Domain.Entities.Common;

namespace TemplateProjectOne.Domain.Entities.Product
{
    public class AddProduct : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 
        public int Count { get; set; }
        public string Brand { get; set; }
        public int Inventory { get; set; }
        public bool ShowOnSite { get; set; }
        public int CountView { get; set; }
       

        //Navigation

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }
        public ICollection<ProductFeature> ProductFeature { get; set; }
    }
}
