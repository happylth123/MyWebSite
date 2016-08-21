using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Share.Enums
{
    public enum IssueStatus
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Open")]
        Open = 0,

        /// <summary>
        /// 
        /// </summary>
        [Description("ReadyFoDevelop")]
        ReadyFoDevelop = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("OnHold")]
        OnHold = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("InProgress")]
        InProgress = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("CodeReview")]
        CodeReview = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("QATesting")]
        QATesting = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("PoReview")]
        PoReview = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("FeedBack")]
        FeedBack = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Done")]
        Done = 8,
    }
}
