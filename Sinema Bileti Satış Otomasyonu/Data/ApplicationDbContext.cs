using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sinema_Bileti_Satış_Otomasyonu.Models;
using Sinema_Bileti_Satış_Otomasyonu.Models.Wiew_models;

namespace Sinema_Bileti_Satış_Otomasyonu.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Rezervasyon> Rezervasyons { get; set; }
        public DbSet<FilmDetaylar> FilmDetaylars { get; set; }
        public DbSet<Seans> Seans { get; set; }
        public DbSet<Koltuk> Koltuks { get; set; }
        public DbSet<SeansKoltuk> SeansKoltuks { get; set; }
        public DbSet<Bilet> Bilets { get; set; }


    }
}