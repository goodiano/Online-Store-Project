namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForSite
{
    public class DetailProductForSiteDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> Images { get; set; }
        public List<GetFeaturesDto> Features { get; set; }
    }
}
