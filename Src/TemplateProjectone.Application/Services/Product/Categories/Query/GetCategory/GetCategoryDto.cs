namespace TemplateProjectOne.Application.Services.Product.Categories.Query.GetCategory
{
    public class GetCategoryDto
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public bool HasChild { get; set; }
        public ParentCategoryDto parent { get; set; }

    }


}
