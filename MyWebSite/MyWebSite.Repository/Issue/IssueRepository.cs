using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSite.EF;
using MyWebSite.Models;

namespace MyWebSite.Repository.Issue
{
    public class IssueRepository : MyWebSiteContext
    {
        public IQueryable<Models.Issue> GetAllIssues()
        {
            return GetAsQueryable<Models.Issue>();
        }

        public Models.Issue GetIssuetByIssueId(string issueId)
        {
            //FirstOrDefault,这样取当没有的时候回返回null，不像select 没有对象就报错
            var customer = Issues.FirstOrDefault(it => it.Id == issueId);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public Models.Issue GetIssuetByIssueIDNum(string issueIDNum)
        {
            //FirstOrDefault,这样取当没有的时候回返回null，不像select 没有对象就报错
            var customer = Issues.FirstOrDefault(it => it.Id == issueIDNum);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public void CreateIssue(Models.Issue issue)
        {
            Add<Models.Issue>(issue);
            SaveChanges();
        }

        public void UpdateIssue(Models.Issue issue)
        {
            if (issue == null)
            {
                return;
            }
            Update<Models.Issue>(issue);
            SaveChanges();
        }

        public void DeleteIssue(string issueId)
        {
            //级联删除，取出子表中外键是父表的ID的数据
            var issueLogWorks = base.IssueLogWorks.Where(it => it.Issue.Id == issueId).ToList();

            Models.Issue issue = base.Issues.Find(issueId);
            Issues.Remove(issue);
            SaveChanges();
        }



    }
}
