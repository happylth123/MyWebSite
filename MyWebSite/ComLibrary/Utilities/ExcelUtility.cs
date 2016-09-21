using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace RealNext.Infrastructure.Utilities
{
    /// <summary>
    /// Excel utility
    /// </summary>
    public class ExcelUtility
    {
        /// <summary>
        /// cell datetime format
        /// </summary>
        public const string CellDateTimeFormat = "dd/MM/yyyy";

        /// <summary>
        /// cell price format
        /// </summary>
        public const string CellPriceFormat = "€ #0";

        /// <summary>
        /// cell decimal format
        /// </summary>
        public const string CellDecimalFormat = "#0.00";

        /// <summary>
        /// Export datatable to excel and return the excel file as a byte array
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="printHeaders"></param>
        public static byte[] GenerateExcel(DataTable dataTable, bool printHeaders = true)
        {
            using (ExcelPackage objExcelPackage = new ExcelPackage())
            {
                //Create the worksheet    
                ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add("Sheet1");

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1    
                objWorksheet.Cells["A1"].LoadFromDataTable(dataTable, printHeaders);
                CellDataFormat(dataTable, objWorksheet, 1, printHeaders);
                objWorksheet.Cells.AutoFitColumns();

                //Format the header    
                using (ExcelRange objRange = objWorksheet.Cells["A1:XFD1"])
                {
                    objRange.Style.Font.Bold = true;
                    objRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    objRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                return objExcelPackage.GetAsByteArray();
            }
        }

        /// <summary>
        /// Export DataSet to excel and return the excel file as a byte array
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="inOneWorksheet">True: all datatables in one worksheet; False: each datatable in one worksheet</param>
        /// <param name="dateTimeCellFormat"></param>
        /// <param name="decimalCellFormat"></param>
        /// <param name="printHeaders"></param>
        /// <returns></returns>
        public static byte[] GenerateExcel(DataSet dataSet, bool inOneWorksheet, string dateTimeCellFormat, string decimalCellFormat, params bool[] printHeaders)
        {
            if (dataSet == null || dataSet.Tables.Count == 0)
            {
                return null;
            }

            using (ExcelPackage objExcelPackage = new ExcelPackage())
            {
                if (inOneWorksheet)
                {
                    //Create the worksheet    
                    ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add("Sheet1");

                    int startRow = 1;
                    for (int i = 0; i < dataSet.Tables.Count; i++)
                    {
                        bool printHeader = (printHeaders.Length > i) ? printHeaders[i] : false;
                        objWorksheet.Cells[startRow, 1].LoadFromDataTable(dataSet.Tables[i], printHeader);
                        CellDataFormat(dataSet.Tables[i], objWorksheet, startRow, printHeader, dateTimeCellFormat, decimalCellFormat);
                        startRow += printHeader ? dataSet.Tables[i].Rows.Count + 1 : dataSet.Tables[i].Rows.Count;
                    }

                    objWorksheet.Cells.AutoFitColumns();
                }
                else
                {
                    for (int i = 0; i < dataSet.Tables.Count; i++)
                    {
                        //Create the worksheet    
                        string cursheetName = String.IsNullOrWhiteSpace(dataSet.Tables[i].TableName) ? "Sheet" + i : dataSet.Tables[i].TableName;
                        ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add(cursheetName);
                        bool printHeader = (printHeaders.Length > i) ? printHeaders[i] : false;
                        objWorksheet.Cells["A1"].LoadFromDataTable(dataSet.Tables[i], printHeader);
                        CellDataFormat(dataSet.Tables[i], objWorksheet, 1, printHeader, dateTimeCellFormat, decimalCellFormat);
                        objWorksheet.Cells.AutoFitColumns();
                    }
                }

                return objExcelPackage.GetAsByteArray();
            }
        }

        /// <summary>
        /// Export datatable to excel
        /// </summary>
        /// <param name="excelFilePath">excel physical disk path</param>
        /// <param name="dataTable"></param>
        /// <param name="printHeaders"></param>
        public static void GenerateExcel(string excelFilePath, DataTable dataTable, bool printHeaders = true)
        {
            byte[] excelFileBytes = GenerateExcel(dataTable, printHeaders);

            //Delete existing file with same file name   
            if (File.Exists(excelFilePath))
            {
                File.Delete(excelFilePath);
            }

            //Create excel file on physical disk    
            FileStream objFileStrm = File.Create(excelFilePath);
            objFileStrm.Close();

            //Write content to excel file    
            File.WriteAllBytes(excelFilePath, excelFileBytes);
        }

        /// <summary>
        /// Set cell format if column type is datetime
        /// </summary>
        /// <param name="dateTable"></param>
        /// <param name="worksheet"></param>
        /// <param name="startRow"></param>
        /// <param name="printHeader"></param>
        private static void CellDataFormat(DataTable dateTable, ExcelWorksheet worksheet, int startRow, bool printHeader, string dateTimeCellFormat = "dd-MM-yyyy hh:mm:ss AM/PM", string decimalCellFormat = "#0.00")
        {
            var dateColumns = from DataColumn d in dateTable.Columns
                              where d.DataType == typeof(DateTime)
                              select d.Ordinal + 1;

            var decimalColumns = from DataColumn d in dateTable.Columns
                                 where d.DataType == typeof(decimal)
                                 select d.Ordinal + 1;

            int fromRow = printHeader ? startRow + 1 : startRow;
            int toRow = fromRow + (dateTable.Rows.Count > 0 ? dateTable.Rows.Count - 1 : 0);

            foreach (var dc in dateColumns)
            {
                worksheet.Cells[fromRow, dc, toRow, dc].Style.Numberformat.Format = dateTimeCellFormat;
            }

            foreach (var dc in decimalColumns)
            {
                worksheet.Cells[fromRow, dc, toRow, dc].Style.Numberformat.Format = decimalCellFormat;
            }
        }
    }
}
