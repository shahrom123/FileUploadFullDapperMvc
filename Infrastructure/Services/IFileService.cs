using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IFileService
    {
       Task<string> CreateFile(string folder, IFormFile file);

        bool DeleteFile(string folder, string fileName);
        List<string> GetListOfFiles(); 
    }
}
