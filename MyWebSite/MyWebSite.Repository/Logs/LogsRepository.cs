using MyWebSite.EF;
using MyWebSite.Models.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Repository.Logs
{
    public class LogsRepository : MyWebSiteContext
    {
        public void WriteDbLog(LogEntity logEntity)
        {
            logEntity.Id = Guid.NewGuid().ToString();
            logEntity.F_Date = DateTime.Now;
            logEntity.F_IPAddress = "192.168.10.232";

            Add<LogEntity>(logEntity);
            SaveChanges();
        }
    }
}
