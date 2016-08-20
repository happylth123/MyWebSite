using MyWebSite.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Models.Account
{
    public class User
    {
        /// <summary>
        /// UserId
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User PassWord
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// UserType
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// DeletedOn time
        /// </summary>
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// CreatedOn time
        /// </summary>
        public DateTime? CreatedOn { get; set; }
    }
}
