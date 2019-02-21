using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL.RehberRepository
{
    public interface IRepositoryBase<TEntity> where TEntity:class
    {
        //ekleme silme guncelleme ve lısteleme 
        //yukarıdakı ıslemlerın ıskeletını verıcem burda 
        //Listeleme için ozellesıyor
        //sebebı classın ıcındekı tum verıyı ıcollectıon 
        //yani liste olarak donmek ıstedıgıcın
        void Add(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> parameter = null);

    }
}
