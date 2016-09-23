using ComLibrary.Log;
using MyWebSite.Models.Logs;
using MyWebSite.Service.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4net.Controllers
{
    public class HomeController : Controller
    {
        LogsService _logsService = new LogsService();

        public Log FileLog
        {
            get { return LogFactory.GetLogger(this.GetType().ToString()); }
        }
        // GET: Home
        public ActionResult Index()
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_Description = "测试";
            _logsService.WriteDbLog(logEntity);

            return View();
        }
    }
}