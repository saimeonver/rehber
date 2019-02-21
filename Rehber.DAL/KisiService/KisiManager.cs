using Rehber.DAL.RehberManagament;
using Rehber.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL.KisiService
{
    //controller gıbı gıt guncelle deyıcem emrı burda verıyorum requestı ıletıyor
    public class KisiManager
    {
        KisiRepository _kisiRepository;
        public KisiManager()
        {
            _kisiRepository = new KisiRepository();
        }
        //newlme ıslemım her zaman constroctor ıcınde olmalı
        public string AddKisi(Kisi item)
        {
            //metodum strng cunku mesaj döndürmesini istiyorum
            try
            {
                _kisiRepository.Add(item);
                return "Ekleme İşlemi Başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public string Update(Kisi item)
        {
            try
            {
                _kisiRepository.Update(item);
                return "Update İşlemi Basarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public string DeleteKisi(Kisi item)
        {
            try
            {
                _kisiRepository.Delete(item);
                return "Silme işlemi başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public ICollection<Kisi> GetAllKisi(Expression<Func<Kisi, bool>> parameter = null)
        {
            return _kisiRepository.GetAll(parameter);
        }
    }
}

