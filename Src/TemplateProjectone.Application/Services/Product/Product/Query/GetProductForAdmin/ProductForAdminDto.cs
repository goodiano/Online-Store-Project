namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForAdmin
{
    public class ProductForAdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Inventory { get; set; }
        public bool ShowOnSite { get; set; }
        public string Category { get; set; }
    }
}
