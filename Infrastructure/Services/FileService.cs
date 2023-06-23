using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public List<string> GetListOfFiles()
        {
            var list = new List<string>();
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var files = Directory.GetFiles(path);
            list.AddRange(files);
            var dirictories = Directory.GetDirectories(path);
            list.AddRange(dirictories);
            return list.ToList(); 
        }
        public async Task<string> CreateFile(string folder, IFormFile file)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, folder, file.FileName);
            using(var stream = new FileStream(path, FileMode.Create))
            {
              await file.CopyToAsync(stream);
            } 
            return file.FileName; 
        }

        public bool DeleteFile(string folder, string fileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, folder, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
