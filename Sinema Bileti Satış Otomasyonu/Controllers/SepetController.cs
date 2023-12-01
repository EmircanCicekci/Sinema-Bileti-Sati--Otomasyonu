using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sinema_Bileti_Satış_Otomasyonu.Data;
using Sinema_Bileti_Satış_Otomasyonu.Models;

namespace Sinema_Bileti_Satış_Otomasyonu.Controllers
{
    public class SepetController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;
        public SepetController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var item = _context.Carts.Where(a => a.UserId == _userManager.GetUserId(HttpContext.User)).ToList();
            return View(item);
        }

        public IActionResult sepetEmty()
        {
            TempData["bossepet"] = "Boş Sepet";
            return View();
        }
        [HttpGet]
        public IActionResult proceed(Cart cart)
        {
            var sepetlist = _context.Carts.Where(a => a.UserId == _userManager.GetUserId(HttpContext.User)).ToList();
            if (sepetlist.Count == 0)
            {
                return RedirectToAction("sepetBos", "sepet");
            }
            else
            {
                return View(sepetlist);
            }

        }
    }
}
