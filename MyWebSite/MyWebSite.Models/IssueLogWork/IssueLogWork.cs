using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Models.IssueLogWork
{
    public class IssueLogWork
    {
        /// <summary>
        /// IssueLogWork Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Log issue User Name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Issue start Time
        /// </summary>
        public DateTime? DateStarted { get; set; }

        /// <summary>
        /// Issue Log Description
        /// </summary>
        public string IssueLogDescription { get; set; }

        /// <summary>
        /// Log Time Minute
        /// </summary>
        public string TimeSpent { get; set; }

        /// <summary>
        /// the log CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// issue
        /// </summary>
        public virtual Issue.Issue Issue { get; set; }
    }
}
