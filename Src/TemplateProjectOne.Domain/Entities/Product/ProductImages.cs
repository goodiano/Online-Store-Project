using TemplateProjectOne.Domain.Entities.Common;

namespace TemplateProjectOne.Domain.Entities.Product
{
    public class ProductImages : BaseEntity
    {
        public AddProduct Product { get; set; }
        public int ProductId { get; set; }
        public string Src { get; set; }
    }
}
