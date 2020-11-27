using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchSite.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string CurrentRoute { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            //ViewData["CurrentRoute"] = Request.Path.Value;
        }

        public void OnGet()
        {
            Console.WriteLine(Request.Path.Value);
        }
    }
}
