using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Product.HomePages.HomePageImages;

namespace TemplateProjectone.Application.Services.HomePages.Command.AddHomePageImages
{
    public class AddHomePageImageServices : IAddHomePageImageServices
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddHomePageImageServices(IDataBaseContext context , IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public RegisterDto Execute(AddHomePageImageRequestDto request)
        {
            var result = UploadFile(request.file);
            HomePageImages homePageImages = new HomePageImages()
            {
                Id = request.Id,
                Link = request.Link,
                Src = result.FileNameAddress,
                Description = request.Description,
                Title = request.Title,
                LocationImages = request.LocationImages,
                Price = request.Price
            };

            _context.HomePageImages.Add(homePageImages);
            homePageImages.InsertTime = DateTime.Now;

            _context.SaveChanges();

            return new RegisterDto()
            {
                IsSuccess = true
            };
        }

        private UploadDto UploadFile(IFormFile file)
            {
                if (file != null)
                {
                    string folder = $@"images\HomePages\HomePageImages\";
                    var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                    if (!Directory.Exists(uploadsRootFolder))
                    {
                        Directory.CreateDirectory(uploadsRootFolder);
                    }


                    if (file == null || file.Length == 0)
                    {
                        return new UploadDto()
                        {
                            Status = false,
                            FileNameAddress = "",
                        };
                    }

                    string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                    var filePath = Path.Combine(uploadsRootFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    return new UploadDto()
                    {
                        FileNameAddress = folder + fileName,
                        Status = true,
                    };
                }
                return null;
            }
        }
    }

