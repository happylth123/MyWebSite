using MyWebSite.Models.Account;
using MyWebSite.Repository.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Service
{
    public class AccountService
    {
        private AccountRepository _accountRepository = new AccountRepository();

        public IList<User> GetAllUsers()
        {
            return _accountRepository.GetAllUsers();
        }

    }
}
