using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint : T yi sınırlandırmak (Filtrelemek) için
    //class : referans tip 
    //IEntity : IEntiy olabilir veya IEntity den implemente eden bir nesne olabilir veri tabanı tablosu görevi görüyor 
    //new() : new lenebilir olmalı çünkü IEntity newlenemez ınterface oldugu için 

    public interface IEntityRepository<T> where T:class ,IEntity,new()  // T bir referans tip olmalı ve T ya IEntity olmalı ya da IEntityden implemente olan bir sey olmalı 
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);     //filtreleme yöntemi kullanmak için 
        T Get(Expression<Func<T, bool>> filter);                  //tek bir elemanı getirme ve detaya inmek için 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
