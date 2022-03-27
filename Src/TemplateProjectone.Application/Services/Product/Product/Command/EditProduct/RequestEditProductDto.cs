namespace TemplateProjectOne.Application.Services.Product.Product.Command.EditProduct
{
    public class RequestEditProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Inventory { get; set; }
        public bool ShowOnSite { get; set; }
    }
}
