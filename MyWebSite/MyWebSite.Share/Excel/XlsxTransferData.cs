using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Share.Excel
{
    public class XlsxTransferData : ExcelTransferData
    {
        public override Stream GetStream(DataTable table)
        {
            base._workBook = new XSSFWorkbook();
            return base.GetStream(table);
        }

        public override DataTable GetDataTable(Stream stream)
        {
            base._workBook = new XSSFWorkbook(stream);
            return base.GetDataTable(stream);
        }
    }
}
