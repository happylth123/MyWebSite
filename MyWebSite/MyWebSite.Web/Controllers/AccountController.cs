using MyWebSite.Service.AccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserService _userService = new UserService();

        // GET: Account
        public ActionResult Index()
        {
            var model = _userService.GetAllUsers();
            return View();
        }
    }
}