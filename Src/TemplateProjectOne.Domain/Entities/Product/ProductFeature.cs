using TemplateProjectOne.Domain.Entities.Common;

namespace TemplateProjectOne.Domain.Entities.Product
{
    public class ProductFeature : BaseEntity
    {
        public AddProduct Product { get; set; }
        public int ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
