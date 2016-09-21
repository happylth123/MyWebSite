using MyWebSite.Share.Excel;
using RealNext.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ExportExcel.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExportToExcel()
        {
            DataTable testDataTable = new DataTable();
            //添加表头
            testDataTable.Columns.Add("Name", typeof(string));
            testDataTable.Columns.Add("Address", typeof(string));
            testDataTable.Columns.Add("Email", typeof(string));
            testDataTable.Columns.Add("Telephone", typeof(string));

            //循环添加每一行数据，可以从数据库获得数据后，foreach循环出来
            //Actually here should add dataRow in foreach from sql data
            DataRow dataRow = testDataTable.NewRow();
            dataRow["Name"] = "test1";
            dataRow["Address"] = "福建";
            dataRow["Email"] = "test1@test.com";
            dataRow["Telephone"] = "123456";
            testDataTable.Rows.Add(dataRow);

            DataRow dataRow2 = testDataTable.NewRow();
            dataRow2["Name"] = "test2";
            dataRow2["Address"] = "浙江";
            dataRow2["Email"] = "test2@test.com";
            dataRow2["Telephone"] = "234567";
            testDataTable.Rows.Add(dataRow2);


            #region Export datatable to excel and return the excel file as a byte array
            HttpResponseMessage response = new HttpResponseMessage();
            byte[] fileBytes = ExcelUtility.GenerateExcel(testDataTable, true);

            if (fileBytes != null)
            {
                response.Content = new ByteArrayContent(fileBytes);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = "test" + ".xlsx";
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                response.Content.Headers.ContentLength = fileBytes.Length;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NoContent;
            }
            #endregion


            #region Export datatable to excel,Create excel file on physical disk
            string exportPath = string.Format("{0}/{1}", "/ExcelExportFile", DateTime.Now.ToString("yyyy-MM-dd"));
            string exportDirPath = Request.MapPath(exportPath);
            if (!Directory.Exists(exportDirPath))
            {
                Directory.CreateDirectory(exportDirPath);
            }

            string exportFileName = Guid.NewGuid().ToString("N") + ".xlsx";

            string exportFilePath = Path.Combine(exportDirPath, Guid.NewGuid().ToString("N") + ".xlsx");
            //write to dick
            ExcelUtility.GenerateExcel(exportFilePath, testDataTable, true);

            //download the excel 
            byte[] downloadFileBytes = System.IO.File.ReadAllBytes(exportFilePath);
            return File(downloadFileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, exportFileName);

            #endregion
        }


    }
}