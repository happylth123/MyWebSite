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
            //_sprintService.DeleteSprint("test");

            var users = _accountService.GetAllUsers();
            return View();
        }

    }
}