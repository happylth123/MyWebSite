using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Share.Excel
{
    public interface ITransferData
    {
        Stream GetStream(DataTable table);
        DataTable GetDataTable(Stream stream);
    }
}
