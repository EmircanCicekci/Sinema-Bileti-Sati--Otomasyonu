using System.ComponentModel.DataAnnotations.Schema;

namespace Sinema_Bileti_Satış_Otomasyonu.Models
{
    public class Rezervasyon
    {
        public int Id { get; set; }
        public string Koltukno { get; set; }
        public string UserId { get; set; }
        public DateTime Datetopresent { get; set; }
        public int FilmDetaylarId { get; set; }
        public int Miktar { get; set; }

        [ForeignKey("FilmDetaylarId")]
        public virtual FilmDetaylar filmdetaylar { get; set; }
    }
}
