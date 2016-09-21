using MyWebSite.Share.Excel;
using RealNext.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
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


        public ActionResult UploadIssue()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadIssue(HttpPostedFileBase file)  //this  "HttpPostedFileBase file" ,the file should the same to the html  input the name  <input type="file" id="dataFile" name="file" class="btn btn-default" />
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileExt = Path.GetExtension(file.FileName).ToLower();

                    string path = string.Format("{0}/{1}", "/ExcelUploadFile", DateTime.Now.ToString("yyyy-MM-dd"));
                    string fileName = string.Format("{0}{1}", Guid.NewGuid().ToString("N"), fileExt);
                    string sqlPath = string.Format("{0}/{1}", path, fileName);
                    string dirPath = Request.MapPath(path);
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    try
                    {
                        file.SaveAs(Path.Combine(dirPath, fileName));
                        file.InputStream.Dispose();
                        //todo: 存数据库的Code  把路径存到数据库  和其他的逻辑



                        string fileLocation = Path.Combine(dirPath, fileName).ToString();
                        FileStream stream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                        var util = TransferDataFactory.GetUtil(fileLocation);
                        var dataTable = util.GetDataTable(stream);
                        //var mStream = util.GetStream(dataTable);   

                        int succeedCount = 0;
                        int failedCount = 0;
                        List<string> failedIssues = new List<string>();

                        if (dataTable == null || dataTable.Rows.Count < 0)
                        {
                            return null;
                        }

                        var sprintIDIndex = 0;
                        var issueIDIndex = 0;
                        var issueTitleIndex = 0;
                        var issueTypeIndex = 0;
                        var originalEstimateIndex = 0;

                        //the excel title row
                        var titleRow = dataTable.Rows[0];
                        for (var i = 0; i < titleRow.ItemArray.Count(); i++)
                        {
                            if (titleRow.ItemArray[i].ToString() == "Sprint")
                            {
                                sprintIDIndex = i;
                            }
                            if (titleRow.ItemArray[i].ToString() == "Issue key")
                            {
                                issueIDIndex = i;
                            }
                            if (titleRow.ItemArray[i].ToString() == "Summary")
                            {
                                issueTitleIndex = i;
                            }
                            if (titleRow.ItemArray[i].ToString() == "Issue Type")
                            {
                                issueTypeIndex = i;
                            }
                            if (titleRow.ItemArray[i].ToString() == "Original Estimate")
                            {
                                originalEstimateIndex = i;
                            }
                        }

                        #region Export datatable to excel and return the excel file as a byte array
                        HttpResponseMessage response = new HttpResponseMessage();
                        byte[] fileBytes = ExcelUtility.GenerateExcel(dataTable, true);

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

                        string exportFileName = Path.Combine(exportDirPath, Guid.NewGuid().ToString("N") + ".xlsx");
                        //write to dick
                        ExcelUtility.GenerateExcel(exportFileName, dataTable, true);

                        #endregion



                        for (var i = 1; i < dataTable.Rows.Count; i++)
                        {
                            var row = dataTable.Rows[i];
                            if (row == null)
                            {
                                continue;
                            }
                        }
                        ViewData["failedIssues"] = failedIssues;
                        ViewBag.ImportSucceedIssueMsg = "Upload Succeed.  " + "succeedCount:" + succeedCount + " ,  " + "failedCount:" + failedCount;
                    }
                    catch
                    {
                        //return Json(new { status = false, msg = "操作失败" });
                    }
                }
                else
                {
                    ModelState.AddModelError("ErrorMessage", "please select file!");
                }
            }
            return View();
        }

    }
}