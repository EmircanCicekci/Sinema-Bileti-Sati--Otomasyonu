using System.ComponentModel.DataAnnotations.Schema;

namespace Sinema_Bileti_Satış_Otomasyonu.Models
{
    public class Bilet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SeansKoltukId { get; set; }

        [ForeignKey("SeansKoltukId")]
        public virtual SeansKoltuk seanskoltuk { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }
    }
}
