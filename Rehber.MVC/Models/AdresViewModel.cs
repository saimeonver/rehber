using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rehber.MVC.Models
{
    public class AdresViewModel//entıtyden dırek cekmek yerıne boyle daha guvenlı vıew modelden cekıyorum
    {
        public int AdresID { get; set; }
        [Required(ErrorMessage ="İl Alanı boş geçilemez")]
        [MaxLength(20,ErrorMessage ="İl Alanı Maksimum 20 Karakter olabilir")]
        public string İl { get; set; }
        [Required(ErrorMessage = "İlce Alanı boş geçilemez")]
        [MaxLength(20, ErrorMessage = "İlce Alanı Maksimum 20 Karakter olabilir")]
        public string İlce { get; set; }
        public int KisiID { get; set; }
    }
}