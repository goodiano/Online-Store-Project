using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Product.Command.EditProduct
{
    public class EditProductServices : IEditProductServices
    {
        private readonly IDataBaseContext _context;
        public EditProductServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(RequestEditProductDto request)
        {
            var product = _context.AddProducts.Find(request.Id);
            if (product == null)
            {
                return new RegisterDto()
                {
                    IsSuccess = false,
                    Message = "عملیات ناموفق بود"
                };
            }

            product.UpdateTime = DateTime.Now;
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Brand = request.Brand;
            product.Inventory = request.Inventory;
            product.ShowOnSite = request.ShowOnSite;

            _context.SaveChanges();
            return new RegisterDto()
            {
                IsSuccess = true,
                Message = "عملیات موفق بود"
            };

        }
    }
}
