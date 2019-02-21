using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rehber.MVC.Models
{
    public class KisiViewModel
    {
        public int KisiID { get; set; }
        [Required(ErrorMessage = "Ad Alanı boş geçilemez")]
        [MaxLength(20, ErrorMessage = "Ad Alanı Maksimum 20 Karakter olabilir")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Soyad Alanı boş geçilemez")]
        [MaxLength(20, ErrorMessage = "Soyad Alanı Maksimum 20 Karakter olabilir")]
        public string Soyadi { get; set; }
        [Range(10,60,ErrorMessage = "Yas alanı 10 ile 60 arasında olabılır")]
        [Required( ErrorMessage = "Yas alanı bos gecilemez")]
        public int Yas { get; set; }
    }
}