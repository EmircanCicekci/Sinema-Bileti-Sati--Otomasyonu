namespace Sinema_Bileti_Satış_Otomasyonu.Models
{
    public class FilmDetaylar
    {
        public int Id { get; set; }
        public string Film_ad { get; set; }
        public string Film_aciklamasi { get; set; }
        //public DateTime Zaman { get; set; }
        public string? FilmResim { get; set; }
        public virtual ICollection<Rezervasyon> rezervasyon { get; set; }

        public virtual ICollection<Seans> seans { get; set; }


    }
}
