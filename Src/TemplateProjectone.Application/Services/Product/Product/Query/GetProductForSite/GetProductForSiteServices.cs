using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForSite
{
    public class GetProductForSiteServices : IGetProductForSiteServices
    {

        private readonly IDataBaseContext _context;
        public GetProductForSiteServices(IDataBaseContext context)
        {
            _context = context;
        }

        public RegisterDto<GetProductForSiteDto> Execute(Ordering ordering, string SearchKey, int Page, int? CatId)
        {
            int totalRow = 0;

            var productQurey = _context.AddProducts
                .Include(p => p.ProductImages).AsQueryable();

            if(CatId != null)
            {
                productQurey = productQurey.Where(p => p.CategoryId == CatId || p.Category.ParentCategoryId == CatId).AsQueryable();
            }

            if (!string.IsNullOrEmpty(SearchKey))
            {
                productQurey = productQurey.Where(p => p.Name.Contains(SearchKey) || p.Brand.Contains(SearchKey) || p.Category.Name.Contains(SearchKey)).AsQueryable();
            }
                var product = productQurey.ToPaged(Page, 5, out totalRow);


            switch (ordering)
            {
                case Ordering.NotOrder:
                    productQurey = productQurey.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    productQurey = productQurey.OrderBy(p => p.CountView).AsQueryable();
                    break;
                case Ordering.theNewest:
                    productQurey = productQurey.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.Bestselling:
                    //TODO: Write BestSelling Code
                    break;
            }





            Random random = new Random();
            return new RegisterDto<GetProductForSiteDto>
            {
                Data = new GetProductForSiteDto
                {
                    TotalRow = totalRow,
                    Products = product.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Price = p.Price,
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                        Title = p.Name,
                        Star = random.Next(1, 5),
                        Inventory = p.Inventory
                        
                    }).ToList()
                },
                IsSuccess = true
            };
        }
    }
}