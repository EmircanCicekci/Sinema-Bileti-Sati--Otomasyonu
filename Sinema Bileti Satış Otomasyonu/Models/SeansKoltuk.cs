using System.ComponentModel.DataAnnotations.Schema;

namespace Sinema_Bileti_Satış_Otomasyonu.Models
{
    public class SeansKoltuk
    {
        public int SeansKoltukID { get; set; }
        public int SeansID { get; set; }
        public int KoltukID { get; set; }
        public bool Dolu { get; set; }
        [ForeignKey("SeansID")]
        public virtual Seans seans { get; set; }
        [ForeignKey("KoltukID")]
        public virtual Koltuk koltuk { get; set; }

        public virtual ICollection<Bilet> bilet { get; set; }
    }
}
