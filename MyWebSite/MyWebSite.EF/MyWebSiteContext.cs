using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSite.Models.Account;
using MyWebSite.Models;
using System.Linq.Expressions;
using MyWebSite.Models.Logs;

namespace MyWebSite.EF
{
    public class MyWebSiteContext : DbContext
    {
        public MyWebSiteContext()
            : base("MyWebSiteContext")
        {
        }

        /// <summary>
        /// Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Issue Log Work
        /// </summary>
        public DbSet<IssueLogWork> IssueLogWorks { get; set; }

        /// <summary>
        /// Issue
        /// </summary>
        public DbSet<Issue> Issues { get; set; }

        /// <summary>
        /// Sprint 
        /// </summary>
        public DbSet<Sprint> Sprints { get; set; }

        public DbSet<LogEntity> LogEntities { get; set; }

        /// <summary>
        /// 级联关系
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //.WithOptional(x => x.Issue) 外键可选，就是可以为空
            modelBuilder.Entity<Issue>()
                .HasMany<IssueLogWork>(c => c.IssueLogWorks)
                .WithOptional(x => x.Issue)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);

            // //or  .WithRequired(x => x.Issue) 外键必须不为空
            // modelBuilder.Entity<Issue.Models.Issue>()
            // .HasMany<IssueLogWork>(c => c.IssueLogWorks)
            //  .WithRequired(x => x.Issue)
            //.WillCascadeOnDelete(true);
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sprint>()
                .HasMany<Issue>(c => c.Issues)
                .WithOptional(x => x.Sprint)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }

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
        //public virtual IQueryable<T> Include<T>(IQueryable<T> queryable, string path) where T : class
        //{
        //    return queryable.Include(path);
        //}

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
        /// Updates the specified items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        //public virtual void Update<T>(IEnumerable<T> items) where T : class
        //{
        //    foreach (T item in items)
        //    {
        //        Update(item);
        //    }
        //}

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
    }
}
