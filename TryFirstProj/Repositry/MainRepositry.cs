﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TryFirstProj.Data;
using TryFirstProj.Repositry.Base;

namespace TryFirstProj.Repositry
{
    public class MainRepositry<T> : IRepositry<T> where T : class
    {
        public MainRepositry(AppDbContext context)
        {
            this.context = context;

        }
        protected AppDbContext context;
        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public T SelectOne(Expression<Func<T, bool>> match)
        {
           return context.Set<T>().FirstOrDefault(match);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();
            if(agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();
            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return await query.ToListAsync();
        }

/// ///////////////////////////////////////////////

        public void AddOne(T myItem)
        {
           context.Set<T>().Add(myItem);
           context.SaveChanges();
        }

        public void DeleteOne(T myItem)
        {
            context.Set<T>().Remove(myItem);
            context.SaveChanges();
        }

        public void UpdateOne(T myItem)
        {
            context.Set<T>().Update(myItem);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> myList)
        {
            context.Set<T>().AddRange(myList);
            context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> myList)
        {
            context.Set<T>().RemoveRange(myList);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> myList)
        {
            context.Set<T>().UpdateRange(myList);
            context.SaveChanges();
        }
    }

}
