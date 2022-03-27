using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForSite
{
    public class GetDetailProductForSiteServices : IGetDetailProductForSiteServices
    {
        private readonly IDataBaseContext _context;
        public GetDetailProductForSiteServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<DetailProductForSiteDto> Execute(int Id)
        {
            var product = _context.AddProducts
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeature)
                .Where(p => p.Id == Id)
                .FirstOrDefault();

            if (product == null)
            {
                throw new Exception("محصول یافت نشد");
            }

            product.CountView++;
            _context.SaveChanges();

            return new RegisterDto<DetailProductForSiteDto>
            {
                Data = new DetailProductForSiteDto
                {
                    Id = product.Id,
                    Brand = product.Brand,
                    Price = product.Price,
                    Inventory = product.Inventory,
                    Title = product.Name,
                    Category = $"{product.Category.ParentCategory.Name} - {product.Category.Name}",
                    Description = product.Description,
                    Images = product.ProductImages.Select(p => p.Src).ToList(),
                    Features = product.ProductFeature.Select(p => new GetFeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList()

                },
                IsSuccess = true
            };

        }
    }
}
