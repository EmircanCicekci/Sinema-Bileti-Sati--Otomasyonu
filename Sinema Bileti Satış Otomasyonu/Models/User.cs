using Microsoft.AspNetCore.Identity;

namespace Sinema_Bileti_Satış_Otomasyonu.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Bilet> bilet { get; set; }
    }
}
