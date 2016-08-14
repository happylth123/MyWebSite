using MyWebSite.Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Domain.Models.Account
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
        public bool Deleted { get; set; }

        /// <summary>
        /// DeletedOn time
        /// </summary>
        public DateTime? DeletedTime { get; set; }

        /// <summary>
        /// CreatedOn time
        /// </summary>
        public DateTime? CreatedTime { get; set; }
    }
}
