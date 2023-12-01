using System.ComponentModel.DataAnnotations.Schema;

namespace Sinema_Bileti_Satış_Otomasyonu.Models
{
    public class Koltuk
    {
        public int KoltukID { get; set; }
        public string KoltukNumarasi { get; set; }
        public string Satir { get; set; }
        public string Sutun { get; set; }
        public virtual ICollection<SeansKoltuk> seanskoltuk { get; set; }
    }
}
