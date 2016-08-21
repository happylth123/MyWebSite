using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Share.Enums
{
    public enum IssueType
    {
        /// <summary>
        /// Task
        /// </summary>
        [Description("Task")]
        Task = 0,

        /// <summary>
        /// Story
        /// </summary>
        [Description("Story")]
        Story = 1,

        /// <summary>
        /// Bug
        /// </summary>
        [Description("Bug")]
        Bug = 2,

        /// <summary>
        /// Epic
        /// </summary>
        [Description("Epic")]
        Epic = 3,

        /// <summary>
        /// Improvement
        /// </summary>
        [Description("Improvement")]
        Improvement = 4
    }
}
