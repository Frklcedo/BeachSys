using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BeachSys.Views.Compartimento
{
    public class Alugar : PageModel
    {
        private readonly ILogger<Alugar> _logger;

        public Alugar(ILogger<Alugar> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}