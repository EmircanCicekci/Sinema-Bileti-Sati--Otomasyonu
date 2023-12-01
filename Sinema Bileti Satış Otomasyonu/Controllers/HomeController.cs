using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sinema_Bileti_Satış_Otomasyonu.Data;
using Sinema_Bileti_Satış_Otomasyonu.Models;
using Sinema_Bileti_Satış_Otomasyonu.Models.Wiew_models;
using System.Diagnostics;

namespace Sinema_Bileti_Satış_Otomasyonu.Controllers
{
    public class HomeController : Controller
    {
        int count = 1;
        bool flag = true;
        private UserManager<User> _userManager;
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BizeUlas()
        {
            return View();
        }

        public IActionResult BiletAl()
        {
            var getMovieList = _context.FilmDetaylars.ToList();
            return View(getMovieList);
        }
        [HttpGet]
        public IActionResult BookNow(int Id) 
        {

            BookNowViewModel vm = new BookNowViewModel();
            var item = _context.FilmDetaylars.Where(a  => a.Id == Id).FirstOrDefault();
            vm.Id = Id;
            vm.Film_ad = item.Film_ad;
            //vm.Film_Tarih = item.Zaman;
            
            return View(vm);
        }
        [HttpPost]

        public IActionResult BookNow(BookNowViewModel vm)
        {
            List<Cart> carts = new List<Cart>();
            string koltukno = vm.KoltukNo.ToString();
            int FilmId = vm.Id;
            string[] koltuknosıra = koltukno.Split(',');
            count = koltuknosıra.Length;
            if (checkseat(koltukno,FilmId)== false)
            {
                foreach (var item in koltuknosıra)
                {
                    carts.Add(new Cart { Miktar = 150, FilmId = vm.Id, UserId = _userManager.GetUserId(HttpContext.User), 
                        //Tarih = vm.Film_Tarih, 
                        Koltukno = item });
                }
                foreach (var item in carts)
                {
                    _context.Carts.Add(item);
                    _context.SaveChanges();
                }
                TempData["Başarılı"] = "Koltuk numaranız ayırtıldı, Sepetiniz kontrol ediniz";
            }
            else
            {
                TempData["Başarısız"] = "Lütfen koltuk numaranızı değiştirin";
            }
            return RedirectToAction("BookNow");
        }

        private bool checkseat(string koltukno, int filmId)
        {
            // throw new NotImplementedException();
            string koltuklar = koltukno;
            string[] koltukrezerv = koltuklar.Split(",");
            var koltuknolist = _context.Rezervasyons.Where(a =>a.FilmDetaylarId==filmId).ToList();
            foreach (var item in koltuknolist)
            {
                string rezerveEt = item.Koltukno;
                foreach (var item1 in koltukrezerv)
                {
                    if (item1 == rezerveEt)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag == false)
                return true;
            else
                return false;
        }
        [HttpPost]
        public IActionResult checkseat(DateTime Film_Zaman, BookNowViewModel bookNow)
        {
            string koltukno = string.Empty;
            var filmlist = _context.Rezervasyons.Where(a =>a.Datetopresent==Film_Zaman).ToList();
            if (filmlist!=null)
            {
                var getkoltukno = filmlist.Where(b=>b.FilmDetaylarId==bookNow.Id).ToList();
                if (getkoltukno!=null)
                {
                    foreach (var item in getkoltukno)
                    {
                        koltukno = koltukno + " " + item.Koltukno.ToString();
                    }
                    TempData["SNO"] = "Rezelve Edilmiş " + koltukno;
                }
            }
            return View();
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