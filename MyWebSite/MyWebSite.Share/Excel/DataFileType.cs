using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Share.Excel
{
    public enum DataFileType
    {
        CSV,
        XLS,
        XLSX
    }

    public class TransferDataFactory
    {
        public static ITransferData GetUtil(string fileName)
        {
            var array = fileName.Split('.');
            var dataType = (DataFileType)Enum.Parse(typeof(DataFileType), array[array.Length - 1], true);
            return GetUtil(dataType);
        }

        public static ITransferData GetUtil(DataFileType dataType)
        {
            switch(dataType)
            {
                case DataFileType.CSV: return new CsvTransferData();
                case DataFileType.XLS: return new XlsTransferData();
                case DataFileType.XLSX: return new XlsxTransferData();
                default: return new CsvTransferData();
            }
        }

    }
}
