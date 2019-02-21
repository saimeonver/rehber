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
    public class KisiRepository : IKisi
    {
        RehberDBContext _db;
        public KisiRepository()
        {
            _db = new RehberDBContext();
        }
        public void Add(Kisi item)
        {
            _db.Kisi.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Kisi item)
        {
            _db.Kisi.Remove(item);
            _db.SaveChanges();
        }

        public ICollection<Kisi> GetAll(Expression<Func<Kisi, bool>> parameter = null)
        {
            return parameter == null ? //nullsa demek tek satır ıf
                 _db.Kisi.ToList() :
                 _db.Kisi.Where(parameter).ToList();
        }

        public void Update(Kisi item)
        {
            Kisi EskiKisi = _db.Kisi.Find(item.KisiID);
            EskiKisi.KisiID = item.KisiID;
            EskiKisi.Adi = item.Adi;
            EskiKisi.Soyadi = item.Soyadi;
            EskiKisi.Yas = item.Yas;

            _db.SaveChanges();
        }
    }
}
