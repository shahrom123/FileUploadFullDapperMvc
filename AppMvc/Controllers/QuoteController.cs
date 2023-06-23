 using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Controllers
{
    public class QuoteController:Controller
    {
        private readonly QuoteService _quoteservice;

        public QuoteController(QuoteService quoteService) 
        {
            _quoteservice = quoteService;
        }
        public async Task<IActionResult> Index()
        {
            var  quotes = await _quoteservice.GetQuotes();
            return View(quotes);
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View(new AddQuoteDto());
        //}
        //[HttpPost]
        //public IActionResult Create(AddQuoteDto quote)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _quoteservice.UploadFileQuote(quote);
        //        return RedirectToAction("index");   
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var existing = _quoteservice.GetQuoteById(id);
        //    var addQuote = new AddQuoteDto()
        //    {
        //        Id = existing.Id,
        //        Author = existing.Result.Author,
        //        CategoryId = existing.Result.CategoryId,
        //        QuoteText = existing.Result.QuoteText,
        //    };

        //    return View(addQuote);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Update(AddQuoteDto quote)
        //{
        //    if (ModelState.IsValid)
        //    {
        //       await _quoteservice.UpdateQuote(quote);   
        //        return RedirectToAction("index");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public async Task<IActionResult> DeleteQuote(int id)
        //{
        //    await _quoteservice.DeleteQuote(id);
        //    return RedirectToAction("index");

        //}
       
    }
}
