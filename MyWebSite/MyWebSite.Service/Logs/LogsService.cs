using MyWebSite.Models.Logs;
using MyWebSite.Repository.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Service.Logs
{
    public class LogsService
    {
        LogsRepository _logsRepository = new LogsRepository();

        public void WriteDbLog(LogEntity logEntity)
        {
            _logsRepository.WriteDbLog(logEntity);
        }
    }
}
