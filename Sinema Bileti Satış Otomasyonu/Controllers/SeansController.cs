using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinema_Bileti_Satış_Otomasyonu.Data;
using Sinema_Bileti_Satış_Otomasyonu.Models;

namespace Sinema_Bileti_Satış_Otomasyonu.Controllers
{
    public class SeansController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public SeansController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index(FilmDetaylar film)
        {
            if(!User.Identity.IsAuthenticated)
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            int filmId = film.Id;
            // filmId'ye göre veritabanından seansları al
            var seanslar = GetSeanslarFromDatabaseAsync(filmId);
            if (seanslar == null)
                return NotFound();

            // Seansları model olarak görüntüle
            return View(seanslar);
        }

        public List<Seans> GetSeanslarFromDatabaseAsync(int filmId)
        {
            // Veritabanı sorgusu yöntemiyle seansları al

            var film = _context.FilmDetaylars.FirstOrDefault(f => f.Id == filmId);

            if (film != null)
            {
                // İlgili film için seansları getirmek için sorgu
                var seanslar = from se in _context.Seans
                               where se.filmdetaylar.Id == filmId
                               select se;

                return seanslar.ToList();
            }
            else
            {
                // İlgili film bulunamadı
                return new List<Seans>();
            }
        }

        public IActionResult SeansSec(int seansId)
        {
           
            Seans secilenSeans = GetSeansFromDatabase(seansId);
            if (secilenSeans == null)
            {
                return BadRequest();
            }
            // Bilet satın alma sayfasına yönlendirme ve seçilen seansı aktarma
            return RedirectToAction("KoltukSecimi", "Bilet", new { seansId = secilenSeans.SeansId });
        }
        public Seans GetSeansFromDatabase(int seansId)
        {
            // Seansı veritabanından çekme
            
            var seans = _context.Seans.FirstOrDefault(x=>x.SeansId == seansId);
            
            return seans;
        }
    }
}
