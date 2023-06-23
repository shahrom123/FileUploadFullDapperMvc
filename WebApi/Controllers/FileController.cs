using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FileController:ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IFileService _fileService;

        public FileController(IWebHostEnvironment environment, IFileService fileService)
        {
            _environment = environment;
            _fileService = fileService;
        }

        [HttpGet("GetListOfFiles")]
        public List<string> GetListOfFiles()
        {
            return  _fileService.GetListOfFiles();
        }

        [HttpPost("AddFile")]
        public async Task<string> CreateFile(string folder, IFormFile file)
        {
            return await _fileService.CreateFile(folder, file); 
        }
         
        [HttpDelete("DeleteFile")]
        public bool DeleteFile(string folder, string fileName)
        {
            return _fileService.DeleteFile(folder, fileName); 
        }
    }
}
