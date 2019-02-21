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
   public  class AdresManager
    {
        //ınsert update delete ıslemlerı ıcın  buradan yonlendırılecek
        //mesajlarımı buradan gonderıcem
        //Crud olarak gecer bu ıslemler 
        //create delete update read 
        //mesajlarımı buradan gonderıcem
        AdresRepository _adresRepository;
        public AdresManager()
        {
            _adresRepository = new AdresRepository();
        }
        //newlme ıslemım her zaman constroctor ıcınde olmalı
        public string AddAdres(Adres item)
        {
            //metodum strng cunku mesaj döndürmesini istiyorum
            try
            {
                _adresRepository.Add(item);
                return "Ekleme İşlemi Başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public string UpdateAdres(Adres item)
        {
            try
            {
                _adresRepository.Update(item);
                return "Update İşlemi Basarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
          
        }
        public string DeleteAdres(Adres item)
        {
            try
            {
                _adresRepository.Delete(item);
                return "Silme işlemi başarılı";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public ICollection<Adres> GetAllAdres(Expression<Func<Adres,bool>>parameter=null)
        {
            return _adresRepository.GetAll(parameter);
        }
    }
}
