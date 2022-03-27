using Microsoft.AspNetCore.Http;

public class RequestAddProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public int Inventory { get; set; }
    public int CategoryId { get; set; }
    public bool ShowOnSite { get; set; }

    public List<FeatureDto> FeatureDto { get; set; }
    public List<IFormFile> Images { get; set; }
}

