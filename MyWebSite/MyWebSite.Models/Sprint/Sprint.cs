using MyWebSite.Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Models
{
    public class Sprint
    {
        /// <summary>
        /// sprint Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Sprint Title
        /// </summary>
        public string SprintIDNum { get; set; }

        /// <summary>
        /// sprint Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// sprint Start Time
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// sprint end Time
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// sprint create Time
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Sprint Modify Time
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// sprint State
        /// </summary>
        public SprintStatus Status { get; set; }

        /// <summary>
        /// Issue
        /// </summary>
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
