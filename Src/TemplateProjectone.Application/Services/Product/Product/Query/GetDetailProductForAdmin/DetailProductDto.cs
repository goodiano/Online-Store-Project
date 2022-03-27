namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForAdmin
{
    public class DetailProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Inventory { get; set; }
        public bool ShowOnSite { get; set; }
        public string Category { get; set; }

        public List<ImageListDto> Images { get; set; }
        public List<FeaturesListDto> Features { get; set; }
    }
}
