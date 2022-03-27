using TemplateProjectOne.Domain.Entities.Product.HomePages.HomePageImages;

namespace TemplateProjectOne.Application.Services.Common.GetHomePageImages
{
    public class GetHomePageImageDto
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public LocationImages LocationImages { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
