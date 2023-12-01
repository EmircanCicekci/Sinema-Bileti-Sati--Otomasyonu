using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sinema_Bileti_Satış_Otomasyonu.Data;
using Sinema_Bileti_Satış_Otomasyonu.Models;
using System.Diagnostics;

namespace Sinema_Bileti_Satış_Otomasyonu.Controllers
{
    public class BiletController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;
        public BiletController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }
        public ActionResult KoltukSecimi(int seansId)
        {
            List<SeansKoltuk> seansKoltuk = _context.SeansKoltuks
        .Include(sk => sk.koltuk)
        .Where(sk => sk.SeansID == seansId)
        .OrderBy(sk => sk.koltuk.Satir)
        .ThenBy(sk => sk.koltuk.Sutun)
        .ToList();

            return View(seansKoltuk);
        }

        [HttpPost]
        public ActionResult BiletAl(string secilenKoltuklar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                if (!string.IsNullOrEmpty(userId))
                {
                    // UserId değeri geçerli
                }
                else
                {
                    return BadRequest();
                }
                List<int> secilenKoltuklarListesi = secilenKoltuklar.Split(',').Select(int.Parse).ToList();



                // Seçilen koltukları işlemek
                List<Bilet> biletler = new List<Bilet>();

                foreach (var koltukId in secilenKoltuklarListesi)
                {
                    var seansKoltuk = _context.SeansKoltuks.FirstOrDefault(sk => sk.SeansKoltukID == koltukId);
                    var bilet = new Bilet
                    {
                        SeansKoltukId = seansKoltuk.SeansKoltukID,
                        UserId = userId,
                        seanskoltuk = seansKoltuk,
                    };
                    
                    biletler.Add(bilet);
                    HttpContext.Session.SetString("SecilenBiletler", JsonConvert.SerializeObject(biletler));
                }
            }
            else
            {
                //return BadRequest();
            }

            
            // Bilet onay sayfasına yönlendirme.
            return RedirectToAction("BiletOnay");
        }

        public ActionResult BiletOnay() 
        {
            var biletler = JsonConvert.DeserializeObject<List<Bilet>>(HttpContext.Session.GetString("SecilenBiletler"));
            
            foreach(var bilet in biletler)
            {
                var koltuk = _context.Koltuks.FirstOrDefault(sk => sk.KoltukID == bilet.seanskoltuk.KoltukID);
                bilet.seanskoltuk.koltuk = koltuk;
                var seans = _context.Seans.FirstOrDefault(sk => sk.SeansId == bilet.seanskoltuk.SeansID);
                bilet.seanskoltuk.seans = seans;
                var film = _context.FilmDetaylars.FirstOrDefault(sk => sk.Id == bilet.seanskoltuk.seans.FilmDetaylarId);
                bilet.seanskoltuk.seans.filmdetaylar = film;
                
                
                //System.Diagnostics.Debugger.Break();

                //Debug.WriteLine(koltukId); 
            }
            return View(biletler);
        }

        public ActionResult BiletOnayTamamla(List<Bilet> biletler)
        {
            foreach (var bilet in biletler)
            {
                var seansKoltuk = _context.SeansKoltuks.FirstOrDefault(sk => sk.SeansKoltukID == bilet.SeansKoltukId);
                bilet.UserId = _userManager.GetUserId(User);
                bilet.seanskoltuk = seansKoltuk;
                bilet.seanskoltuk.Dolu = true;
                _context.Bilets.Add(bilet);
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}
