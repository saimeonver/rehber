using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Entities.Entities.Mapping
{
   public  class AdresMapping:EntityTypeConfiguration<Adres>
    {
        public AdresMapping()
        {
            Property(x => x.İI)
                .HasMaxLength(50)
                .IsRequired();
            Property(x => x.İlce)
               .HasMaxLength(50)
               .IsRequired();
        }
    }
}
