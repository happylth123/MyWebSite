using MyWebSite.Service.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MyWebSite.Web.Controllers
{
    public class IssueController : Controller
    {
        private IssueService _issueService = new IssueService();
        // GET: Issue
        public ActionResult Index()
        {

            var issues = _issueService.GetAllIssues();

            if (issues != null)
            {
                var count = issues.Count();
            }
            if (issues == null)
            {

            }
            if (issues.Count() == 0)
            {

            }

            if (issues.Count() > 0)
            {

            }

            return View();
        }
    }
}