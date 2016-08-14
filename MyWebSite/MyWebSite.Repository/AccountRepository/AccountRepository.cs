using MyWebSite.Date.EF;
using MyWebSite.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Repository.AccountRepository
{
    public class AccountRepository : MyWebSiteDataContext
    {
        public IList<User> GetAllUsers()
        {
            return GetAsQueryable<User>().ToList();
        }
    }
}
