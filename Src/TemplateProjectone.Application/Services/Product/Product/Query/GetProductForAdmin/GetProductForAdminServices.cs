using Microsoft.EntityFrameworkCore;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetProductForAdmin
{
    public class GetProductForAdminServices : IGetProductForAdminServices
    {
        private readonly IDataBaseContext _context;
        public GetProductForAdminServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto<AllProductDto> Execute(int Page = 1, int PageSize = 20)
        {

            int rowcount = 0;
            var product = _context.AddProducts
                .Include(p => p.Category)
                .ToPaged(Page, PageSize, out rowcount)
                .Select(p => new ProductForAdminDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand,
                    Price = p.Price,
                    Description = p.Description,
                    Inventory = p.Inventory,
                    ShowOnSite = p.ShowOnSite,
                    Category = p.Category.Name
                }).ToList();

            return new RegisterDto<AllProductDto>()
            {
                Data = new AllProductDto()
                {
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowcount,
                    Products = product
                },
                IsSuccess = true,
                Message = ""
            };
                
        }
    }
}
