using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;

namespace TemplateProjectOne.Application.Services.Product.Product.Query.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        RegisterDto<List<GetAllCategoryDto>> Execute();
    }


    public class GetAllCategoriesServices : IGetAllCategoriesService
    {
        private readonly IDataBaseContext _context;

        public GetAllCategoriesServices(IDataBaseContext context)
        {
            _context = context;
        }

        public RegisterDto<List<GetAllCategoryDto>> Execute()
        {
            var categories = _context
                .Categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new GetAllCategoryDto
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory.Name} - {p.Name}",
                }
                ).ToList();

            return new RegisterDto<List<GetAllCategoryDto>>
            {
                Data = categories,
                IsSuccess = false,
                Message = "",
            };
        }
    }
}
