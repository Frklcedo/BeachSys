using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BeachSys.Models;

namespace BeachSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BeachSysContext _context;
        private Usuario _user;

        public HomeController(ILogger<HomeController> logger, BeachSysContext context)
        {
            _logger = logger;
            _context = context;
            _user = null;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string login, string senha)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(m => m.Email == login && m.Senha == senha);
            if(usuario == null ){
                ViewBag.message = "Usuário não encontrado";
                return View();
            }
            else{
                TempData["usuario"] = usuario.UsuarioId;
                if(usuario.IsRoot){
                    return RedirectToAction(nameof(Control));
                }
                else{
                    return RedirectToAction(nameof(Index),"Armario");
                }
            }
        }

        public IActionResult Control()
        {
            // if(_user == null){
            //     return RedirectToAction(nameof(Index));
            // }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ControlRedirect(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(m => m.UsuarioId == id);
            TempData["usuario"] = usuario.UsuarioId;
            return RedirectToAction(nameof(Control));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
