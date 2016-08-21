using MyWebSite.EF;
using MyWebSite.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Repository.Account
{
    public class AccountRepository : MyWebSiteContext
    {
        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <returns></returns>
        public IList<User> GetAllUsers()
        {
            return Users.ToList();
        }

    }
}
