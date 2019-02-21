using Rehber.DAL.RehberRepository;
using Rehber.Entities.Entities;
using Rehber.Entities.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL.RehberManagament
{
    class AdresRepository : IAdres
    {
        RehberDBContext _db;//burda new lemedım her tıkladıgımda yenı bır ınstance alamsın dıye
        //su an acık olan baglantıya devam edıcek
        public AdresRepository()
        {
            _db = new RehberDBContext();
        }
        
        public void Add(Adres item)
        {
            _db.Adres.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Adres item)
        {
            _db.Adres.Remove(item);
            _db.SaveChanges();
        }

        public ICollection<Adres> GetAll(Expression<Func<Adres, bool>> parameter = null)
        {
            return parameter == null ? //nullsa demek tek satır ıf
                _db.Adres.ToList() :
                _db.Adres.Where(parameter).ToList();//paremeresı varsa paremetersı olanı lıstelıyorsun
        }

        public void Update(Adres item)
        {
            Adres EskiAdres = _db.Adres.Find(item.AdresID);
            EskiAdres.AdresID = item.AdresID;
            EskiAdres.İlce = item.İlce;
            EskiAdres.İI = item.İI;
           
            
            _db.SaveChanges();
        }
    }
}
