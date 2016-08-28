using MyWebSite.EF;
using MyWebSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Repository
{
    public class SprintRepository : MyWebSiteContext
    {

        /// <summary>
        /// Create Sprint
        /// </summary>
        /// <param name="sprint"></param>
        public void CreateSprint(Sprint sprint)
        {
            Add<Sprint>(sprint);
            SaveChanges();
        }

        /// <summary>
        /// Update Sprint
        /// </summary>
        /// <param name="sprint"></param>
        public void UpdateSprint(Sprint sprint)
        {
            if (sprint == null)
            {
                return;
            }
            Update<Sprint>(sprint);
            SaveChanges();
        }

        /// <summary>
        /// Get All Sprints
        /// </summary>
        /// <returns></returns>
        public IList<Sprint> GetAllSprints()
        {
            return Sprints.ToList();
        }

        /// <summary>
        /// Get Sprint By Sprint Id
        /// </summary>
        /// <param name="sprintId"></param>
        /// <returns></returns>
        public Sprint GetSprintBySprintId(string sprintId)
        {
            //FirstOrDefault,这样取当没有的时候回返回null，不像select 没有对象就报错
            var customer = Sprints.FirstOrDefault(it => it.Id == sprintId);
            if (customer == null)
            {
                return null;
            }

            return customer;
        }

        /// <summary>
        /// Get Sprint By SprintIDNum
        /// </summary>
        /// <param name="sprintIDNum"></param>
        /// <returns></returns>
        public Sprint GetSprintBySprintIDNum(string sprintIDNum)
        {
            var customer = Sprints.FirstOrDefault(it => it.SprintIDNum == sprintIDNum);
            if (customer == null)
            {
                return null;
            }

            return customer;
        }

        /// <summary>
        /// Delete Sprint
        /// </summary>
        /// <param name="sprintId"></param>
        public void DeleteSprint(string sprintId)
        {
            //级联删除，取出子表中外键是父表的ID的数据
            var issues = Issues.Where(it => it.Sprint.Id == sprintId).ToList();
            Sprint sprint = Sprints.Find(sprintId);
            Sprints.Remove(sprint);
            SaveChanges();
        }
    }
}
