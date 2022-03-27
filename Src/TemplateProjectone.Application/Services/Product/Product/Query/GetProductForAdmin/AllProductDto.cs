namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForAdmin
{
    public class AllProductDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<ProductForAdminDto> Products { get; set; }
    }
}
