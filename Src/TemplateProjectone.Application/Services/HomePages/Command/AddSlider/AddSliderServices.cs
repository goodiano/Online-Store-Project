using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TemplateProjectOne.Application.Interfaces.Contextes;
using TemplateProjectOne.Common.Dto;
using TemplateProjectOne.Domain.Entities.Product.HomePages;

namespace TemplateProjectOne.Application.Services.HomePages
{
    public class AddSliderServices : IAddSliderServices
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _env;

        public AddSliderServices(IDataBaseContext context , IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public RegisterDto Execute(IFormFile file, string link , string title , string description)
        {
            var resultUpload = UploadFile(file);

            Sliders slider = new Sliders()
            {
                Src = resultUpload.FileNameAddress,
                Link = link,
                Title = title,
                Description = description
            };
            _context.Sliders.Add(slider);
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
                string folder = $@"images\HomePages\Sliders\";
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

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
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
