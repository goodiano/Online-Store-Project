using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Product;

namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetDetailProductForAdmin
{
    public class GetDetailProductServices : IGetDetailForProductServices
    {

        private readonly IDataBaseContext _context;

        public GetDetailProductServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<DetailProductDto> Execute(int Id)
        {
            var product = _context.AddProducts
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeature)
                .Where(p => p.Id == Id)
                .FirstOrDefault();
            return new RegisterDto<DetailProductDto>()
            {
                Data = new DetailProductDto()
                {
                    Id = product.Id,
                    Brand = product.Brand,
                    Description = product.Description,
                    Inventory = product.Inventory,
                    Name = product.Name,
                    Price = product.Price,
                    ShowOnSite = product.ShowOnSite,
                    Category = GetCategory(product.Category),
                    Features = product.ProductFeature.ToList().Select(p => new FeaturesListDto()
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList(),
                    Images = product.ProductImages.ToList().Select(p => new ImageListDto()
                    {
                        Id = p.Id,
                        Src = p.Src,
                    }).ToList()
                }, 
                IsSuccess = true,
                Message = ""
            };
        }
        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : " ";
            return result += category.Name;
        }
    }
}
