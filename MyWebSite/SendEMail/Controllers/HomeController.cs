using ComLibrary.Mail;
using ComLibrary.Web;
using SendEMail.App_Start._01_Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComLibrary.Json;

namespace SendEMail.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SendMail(string account, string title, string content)
        {
            MailHelper mail = new MailHelper();
            //mail.MailServer = Configs.GetValue("MailHost");
            //mail.MailUserName = Configs.GetValue("MailUserName");
            //mail.MailPassword = Configs.GetValue("MailPassword");
            //mail.MailName = "NFine快速开发平台";
            //mail.Send(account, title, content);
            //return Success("发送成功。");

            //设置邮箱主机
            mail.MailServer = "smtp.qq.com";
            //设置邮箱地址
            mail.MailUserName = "1246623393@qq.com";
            //设置邮箱密码
            mail.MailPassword = "nekpvujpqlzcgjbe";
            //设置邮箱名称
            mail.MailName = "清风辉辉";
            mail.Send(account, title, content);
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = "发送成功。" }.ToJson());
        }
    }
}