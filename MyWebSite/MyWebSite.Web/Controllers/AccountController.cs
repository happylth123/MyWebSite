using MyWebSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Web.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _accountService = new AccountService();
        private SprintService _sprintService = new SprintService();

        // GET: Account
        public ActionResult Index()
        {
            var sprints = _sprintService.GetAllSprints();
            _sprintService.CreateSprint();
            _sprintService.UpdateSprint();


            #region  Dictionary list
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("xingming", "wuyuqing");

            Session["112"] = test;
            var tessts = Session["112"] as Dictionary<string, string>;

            var xingm = "";
            test.TryGetValue("xingming", out xingm);


            List<string> tesst2 = new List<string>();
            tesst2.Add("12");
            tesst2.Add("2");
            #endregion



            //_sprintService.DeleteSprint("test");

            var users = _accountService.GetAllUsers();
            return View();
        }

    }
}