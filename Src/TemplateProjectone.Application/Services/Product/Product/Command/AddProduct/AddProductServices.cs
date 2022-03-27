using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Product;


namespace TemplateProjectOne.Application.Services.Product.Product.Command
{
    public class AddProductServices : IAddProductServices
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _env;
        
        public AddProductServices(IDataBaseContext context , IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public RegisterDto Excute(RequestAddProductDto request)
        {
            try
            {
                var category = _context.Categories.Find(request.CategoryId);
                AddProduct product = new AddProduct()
                {
                    Brand = request.Brand,
                    Description = request.Description,
                    InsertTime = DateTime.Now,
                    Inventory = request.Inventory,
                    Name = request.Name,
                    Price = request.Price,
                    ShowOnSite = request.ShowOnSite,
                    Category = category
                };
                _context.AddProducts.Add(product);

                List<ProductImages> images = new List<ProductImages>();
                foreach (var item in request.Images)
                {
                    var uploadedImage = UploadFile(item);
                    images.Add(new ProductImages()
                    {
                        Product = product,
                        Src = uploadedImage.FileNameAddress
                    });
                }
                _context.ProductImages.AddRange(images);

                List<ProductFeature> features = new List<ProductFeature>();
                foreach (var item in request.FeatureDto)
                {
                    features.Add(new ProductFeature()
                    {
                        DisplayName = item.DisplayName,
                        Value = item.Value,
                        Product = product
                    });
                }
                _context.ProductFeatures.AddRange(features);
                _context.SaveChanges();

                return new RegisterDto
                {
                    IsSuccess = true,
                    Message = "محصول اضافه شد"
                };
            }

            catch (Exception ex)
            {
                return new RegisterDto
                {
                    IsSuccess = false,
                    Message = "عملیات موفق نبود!"
                };
            }
        }

        
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_env.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }

                if (file == null || file.Length == 0)
                {
                    return new UploadDto
                    {
                        Status = false,
                        FileNameAddress = ""
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file. FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return new UploadDto
                {
                    FileNameAddress = folder + fileName,
                    Status = true
                };
            }
            
            return null;
        }
    }
}

