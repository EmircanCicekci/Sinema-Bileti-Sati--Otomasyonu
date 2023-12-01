using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sinema_Bileti_Satış_Otomasyonu.Models
{
    public class Seans
    {
        public int SeansId { get; set; }
        public DateTime FilmSeans { get; set; }
        public int FilmDetaylarId { get; set; }

        [ForeignKey("FilmDetaylarId")]
        public virtual FilmDetaylar filmdetaylar { get; set; }
        public virtual ICollection<SeansKoltuk> seanskoltuk { get; set; }
    }
}
