using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Product.Command.RemoveProduct
{
    public class RemoveProductServices : IRemoveProductServices
    {
        private readonly IDataBaseContext _context;

        public RemoveProductServices(IDataBaseContext context)
        {
            _context = context;
        }
        public RegisterDto Execute(int Id)
        {
            var product = _context.AddProducts
                .Include(p=> p.ProductImages)
                .Where(p=> p.Id == Id)
                .FirstOrDefault();
            if(product != null)
            {
                _context.AddProducts.Remove(product);
                _context.SaveChanges();

                return new RegisterDto
                {
                    IsSuccess = true,
                    Message = "حذف با موفقیت انجام شد"
                };
            }
            else
            {
            return new RegisterDto
            {
                IsSuccess = false,
                Message = "عملیات موفق نبود"
            };
            }

        }
    }
}
