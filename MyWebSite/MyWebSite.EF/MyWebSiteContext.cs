using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSite.Models.Account;

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
    }
}
