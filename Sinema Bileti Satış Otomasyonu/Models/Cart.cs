using System.ComponentModel.DataAnnotations.Schema;

namespace Sinema_Bileti_Satış_Otomasyonu.Models
{
    public class Cart
    {
        public int id { get; set; }
        public string Koltukno { get; set; }
        public string UserId { get; set; }
        //public DateTime Tarih { get; set; }
        public int Miktar { get; set; }
        public int FilmId { get; set; }
        public int SeansId { get; set; }

        [ForeignKey("SeansId")]
        public virtual Seans seans { get; set; }

    }
}
