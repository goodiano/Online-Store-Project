using TemplateProjectOne.Domain.Entities.Product;

namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForSite
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Star { get; set; }
        public string ImageSrc { get; set; }
        public int Inventory { get; set; }

    }
}
