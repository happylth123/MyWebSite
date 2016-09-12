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
        public IQueryable<User> GetAllUsers()
        {
            return GetAsQueryable<Models.Account.User>();
        }

        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            Add<User>(user);
            SaveChanges();
        }

        /// <summary>
        /// UpdateUser
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            if (user == null)
            {
                return;
            }
            Update<User>(user);
            SaveChanges();
        }

        /// <summary>
        /// Get User By UsertId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserByUsertId(string userId)
        {
            //FirstOrDefault,这样取当没有的时候回返回null，不像select 没有对象就报错
            var customer = Users.FirstOrDefault(it => it.Id == userId);
            if (customer == null)
            {
                return null;
            }

            return customer;
        }

        /// <summary>
        /// Get User By UserEmail
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public User GetUserByUserEmail(string userEmail)
        {
            //FirstOrDefault,这样取当没有的时候回返回null，不像select 没有对象就报错
            var customer = Users.FirstOrDefault(it => it.Id == userEmail);
            if (customer == null)
            {
                return null;
            }

            return customer;
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(string userId)
        {
            //级联删除，取出子表中外键是父表的ID的数据
            //var issueLogWork = IssueLogWorks.Where(it => it. == userId).ToList();

            User user = Users.Find(userId);
            Users.Remove(user);
            SaveChanges();
        }

    }
}
