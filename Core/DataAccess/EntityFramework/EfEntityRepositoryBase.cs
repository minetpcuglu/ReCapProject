using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //Bana bir tablo ver ve bir tanede calıscagım tipi ver 
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()          //iş kurallarını yazalım
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //using:IDispossable pattern implementation of c#
            //using bitince bellekten otomatik silinir nedeni performans acısından 

            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // veri kaynagıyla ilişkilendir referansı yakala
                addedEntity.State = EntityState.Added;   //eklencek bir nesne mi sorgula
                context.SaveChanges();                   //ekle ve kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);   // veri kaynagıyla ilişkilendir referansı yakala
                deletedEntity.State = EntityState.Deleted;   //silincek bir nesne mi sorgula
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //tek data gelir
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //filtre verelim :

            using (TContext context = new TContext())
            {
                //Filtre Göndermemişse tüm datayı getir (select * from Car)
                return filter == null ? context.Set<TEntity>().ToList()
                //Filtre varsa  ":"
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // veri kaynagıyla ilişkilendir referansı yakala
                updatedEntity.State = EntityState.Modified; //güncellencek bir nesne mi sorgula
                context.SaveChanges();                      //guncelle ve kaydet
            }
        }
    }

}
