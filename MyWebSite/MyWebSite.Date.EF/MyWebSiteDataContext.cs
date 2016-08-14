using MyWebSite.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Date.EF
{
    public class MyWebSiteDataContext : DbContext
    {
        public MyWebSiteDataContext()
            : base("MyWebSiteDataContext")
        {
        }

        /// <summary>
        /// Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        public virtual void Add<T>(T item) where T : class
        {
            Set(item.GetType()).Add(item);
        }

        /// <summary>
        /// Add the specified items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        //public virtual void Add<T>(IEnumerable<T> items) where T : class
        //{
        //    this.BulkInsert(items);
        //}

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        public virtual void Update<T>(T item) where T : class
        {
            Set(item.GetType()).Attach(item);
            Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Updates the specified items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        public virtual void Update<T>(IEnumerable<T> items) where T : class
        {
            foreach (T item in items)
            {
                Update(item);
            }
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        //public virtual void Remove<T>(T item) where T : class
        //{
        //    if (item is AuditableEntityBase)
        //    {
        //        var entity = item as AuditableEntityBase;
        //        entity.Deleted = true;
        //        entity.UtcDeletedTime = DateTime.UtcNow;
        //    }
        //    else
        //    {
        //        Set(item.GetType()).Remove(item);
        //    }
        //}

        /// <summary>
        /// Removes the specified items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        //public virtual void Remove<T>(IEnumerable<T> items) where T : class
        //{
        //    foreach (T item in items)
        //    {
        //        Remove(item);
        //    }
        //}

        /// <summary>
        /// Gets as queryable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IQueryable<T> GetAsQueryable<T>() where T : class
        {
            return Set<T>();
        }

        /// <summary>
        /// Specifies the related objects to include in the query results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        //public virtual IQueryable<T> Include<T, TProperty>(IQueryable<T> queryable, Expression<Func<T, TProperty>> path) where T : class
        //{
        //    return queryable.Include(path);
        //}

        /// <summary>
        /// Specifies the related objects to include in the query results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Include<T>(IQueryable<T> queryable, string path) where T : class
        {
            return queryable.Include(path);
        }
    }
}
