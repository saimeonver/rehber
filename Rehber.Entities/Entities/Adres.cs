using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Entities.Entities
{
   public  class Adres
    {

        public int AdresID { get; set; }
        public string İI { get; set; }
        public string İlce { get; set; }
        public int KisiID { get; set; }
        public Kisi Kisi { get; set; }
    }
}
