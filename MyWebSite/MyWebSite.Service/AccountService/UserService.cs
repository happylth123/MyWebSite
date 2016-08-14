using MyWebSite.Domain.Models.Account;
using MyWebSite.Repository.AccountRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Service.AccountService
{
    public class UserService
    {
        private AccountRepository _accountRepository = new AccountRepository();

        public IList<User> GetAllUsers()
        {
            return _accountRepository.GetAllUsers();
        }
    }
}
