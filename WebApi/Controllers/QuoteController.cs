using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class QuoteController:ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly QuoteService _quoteService;

        public QuoteController(IWebHostEnvironment webHostEnvironment, QuoteService quoteService)
        {
            _webHostEnvironment = webHostEnvironment;
            _quoteService = quoteService;
        }
        [HttpGet("GetQuoteFile")]
        public async Task<List<GetQuoteDto>> GetQuote()
        {
            return await  _quoteService.GetQuotes(); 
        }
        [HttpPost("UploadFile(AddFile)")]
        public async Task<GetQuoteDto> UploadFile([FromForm]AddQuoteDto quote, string folder)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath);
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
           return await _quoteService.UploadFileQuote(quote); 

        }
        [HttpPut("UpdateQoute(UpdateFile)")]
        public  async Task<GetQuoteDto> UpdateQuote([FromForm] AddQuoteDto quote)
        {
            return await _quoteService.UpdateQuote(quote); 
        }
    }
}
