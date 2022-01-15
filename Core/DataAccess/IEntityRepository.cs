using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint : where T:class ;
    //diyerek bu interfacei implement eden sınıflara int string gibi veri tipi değil,
    //sadece referans tip gönderilme kısıtını sağlamış oluyoruz.
    //,IEntity diyerek de sadece IEntity interfaceini implemente eden
    //referans tipli objelerin gönderilebileceği kısıtını koymuş oluyoruz.
    //,new() diyerek de sadece obje gönderme kısıtı koyuyoruz
    //bunu yapmazsak IEntity tipi direkt gönderilebilir fakat bu hata olur.
    //Buraya gönderilen gerçek newlenebilir bir nesne olmalıdır.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        //expression parametre olarak linq sorgusu almayı sağlar.
        //filter=null sayesinde filtre vermeyebilirsin de demiş oluyoruz.
        //Bu sayede Get all by category methoduna ihtiyaç kalmamış oluyor
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCategoryId(int categoryId);
    }
}
