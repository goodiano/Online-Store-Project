using Microsoft.AspNetCore.Http;
using TemplateProjectOne.Domain.Entities.Product.HomePages.HomePageImages;

public class AddHomePageImageRequestDto
{
    public int Id { get; set; }
    public string Src { get; set; }
    public string Link { get; set; }
    public IFormFile file { get; set; }
    public LocationImages LocationImages { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}

