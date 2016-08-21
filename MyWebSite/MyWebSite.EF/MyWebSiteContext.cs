using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSite.Models.Account;
using MyWebSite.Models.IssueLogWork;
using MyWebSite.Models.Issue;
using MyWebSite.Models.Sprint;

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
    }
}
