using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Share.Enums
{
    public enum UserType
    {
        /// <summary>
        /// Anonymous the user who does no login
        /// </summary>
        [Description("Anonymous")]
        Anonymous = 0,

        /// <summary>
        /// the Administrator
        /// </summary>
        [Description("Administrator")]
        Administrator = 1
    }
}
