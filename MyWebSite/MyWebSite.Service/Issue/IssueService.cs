using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSite.Models;
using MyWebSite.Repository;
using MyWebSite.Repository.Issue;
using PagedList;

namespace MyWebSite.Service.Issue
{
    public class IssueService
    {
        private IssueRepository _issueRepository = new IssueRepository();
        public IList<Models.Issue> GetAllIssues()
        {
            int pageNumber = 1;
            int pageSize = 3;

            var query = _issueRepository.GetAllIssues();
            var totalcount = query.Count();
            return query.OrderBy(it => it.Id).ToPagedList(pageNumber, pageSize).ToList();

        }

    }
}
