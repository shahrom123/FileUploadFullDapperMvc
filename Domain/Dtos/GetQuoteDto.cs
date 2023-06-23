using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class QuoteDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please fill the Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "please fill the QuoteText")]
        public string QuoteText { get; set; }
        [Required(ErrorMessage = "please fill the CategoryId")]
        public int CategoryId { get; set; }
    }

    public class GetQuoteDto : QuoteDto
    {
        public string FileName { get; set; }
    }
    public class AddQuoteDto:QuoteDto
    { 
        public IFormFile File { get; set; }    
    }


}
