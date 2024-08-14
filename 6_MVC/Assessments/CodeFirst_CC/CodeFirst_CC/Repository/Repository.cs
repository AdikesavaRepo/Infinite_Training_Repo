using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirst_CC.Models;
using System.Data.Entity;

namespace CodeFirst_CC.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ContextClass db;
        DbSet<T> dbset;

        public Repository()
        {
            db = new ContextClass();
            dbset = db.Set<T>();
        }
        public void Delete(object Id)
        {
            T getmodel = dbset.Find(Id);
            dbset.Remove(getmodel);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetById(object Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T obj)
        {
            dbset.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}