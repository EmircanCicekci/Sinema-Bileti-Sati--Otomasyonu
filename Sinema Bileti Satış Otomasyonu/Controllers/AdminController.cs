using FileUploadControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sinema_Bileti_Satış_Otomasyonu.Data;
using Sinema_Bileti_Satış_Otomasyonu.Models;
using Sinema_Bileti_Satış_Otomasyonu.Models.Wiew_models;

namespace Sinema_Bileti_Satış_Otomasyonu.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UploadInterface _upload;
        public AdminController(ApplicationDbContext context, UploadInterface upload)
        {
            _upload = upload;
            _context = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var getMovieList = _context.FilmDetaylars.ToList();
            return View(getMovieList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IList<IFormFile> files, filmdetaylarviewmodel vmodel, FilmDetaylar movie)
        {
            string path = string.Empty;
            movie.Film_ad = vmodel.Ad;
            movie.Film_aciklamasi = vmodel.Tanım;
            //movie.Zaman = vmodel.FilmTarih;

            foreach (var item in files)
            {
                path = Path.GetFileName(item.FileName.Trim());
                movie.FilmResim = "~/uploads/" + path;

            }

            _upload.uploadfilemultiple(files);
            _context.FilmDetaylars.Add(movie);
            _context.SaveChanges();
            TempData["sucess"] = "Save Your Movie";
            return RedirectToAction("Create", "Admin");
        }
        [HttpGet]
        public IActionResult CheckBookSeat()
        {
            var getRezervasyon = _context.Rezervasyons.ToList().OrderByDescending(a => a.Datetopresent);
            return View(getRezervasyon);
        }
        [HttpGet]
        public IActionResult GetUserDetails()
        {
            var getUserTable = _context.Users.ToList();
            return View(getUserTable);
        }

        public IActionResult DeleteFilm(int id)
        {
            var film = _context.FilmDetaylars.Find(id);

            if (film == null)
            {
                // Eğer film bulunamazsa, hata mesajı gösterilebilir
                return BadRequest();
            }

            // Film veritabanından silinir
            _context.FilmDetaylars.Remove(film);
            _context.SaveChanges();

            // Başarılı bir şekilde silindiğinde yönlendirme yapılabilir
            return RedirectToAction("Index", "Admin");

        }

        public IActionResult SeansEkle(int id)
        {
            var film = _context.FilmDetaylars.Find(id);
            if (film == null)
                return NotFound();
            Seans seans = new Seans{filmdetaylar = film };
            return View(seans);
        }
        [HttpPost]
        public IActionResult SeansEkle(int id, Seans seans)
        {
            seans.FilmDetaylarId = id;
            _context.Seans.Add(seans);// seans eklendi
            _context.SaveChanges();

            List<Koltuk> tumKoltuklar = _context.Koltuks.ToList();

            foreach (Koltuk koltuk in tumKoltuklar)
            {
                // Yeni bir SeansKoltuk nesnesi oluşturur
                SeansKoltuk yeniSeansKoltuk = new SeansKoltuk
                {
                    SeansID = seans.SeansId,
                    KoltukID = koltuk.KoltukID,
                    Dolu = false
                };

                // SeansKoltuklar tablosuna yeni satırı ekleme
                _context.SeansKoltuks.Add(yeniSeansKoltuk);
            }
            _context.SaveChanges();   
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult KoltukEkle()
        {
            List<string> satir = new List<string>();
            satir.Add("A");
            satir.Add("B");
            satir.Add("C");
            satir.Add("D");
            satir.Add("E");
            List<string> sutun = new List<string>();
            sutun.Add("1");
            sutun.Add("2");
            sutun.Add("3");
            sutun.Add("4");
            sutun.Add("5");
            sutun.Add("6");
            sutun.Add("7");
            sutun.Add("8");
            sutun.Add("9");
            



            foreach (string a in satir)
            {
                foreach(string b in sutun)
                {
                    Koltuk koltuk = new Koltuk
                    {
                        Satir = a,
                        Sutun = b,
                        KoltukNumarasi = a + b
                    };
                    var koltukAramasi = _context.Koltuks.FirstOrDefault(a => a.KoltukNumarasi == koltuk.KoltukNumarasi);
                    if (koltukAramasi == null)
                        _context.Koltuks.Add(koltuk);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult KoltukSil()
        {
            return RedirectToAction("Index", "Admin");
        }

    }


}
