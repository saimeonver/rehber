using Rehber.Entities.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Entities.Entities.Context
{
    public class RehberDBContext:DbContext
    {
        public RehberDBContext():base
            ("RehberConnectionstring")
        {

        }

        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<Adres> Adres { get; set; }
        //model olusturmadan burda map etmesınoı saglıyor databse otomatık olarak olusuyo bu sayede
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KisiMapping());
            modelBuilder.Configurations.Add(new AdresMapping());
        }
    }
}
