using CoreReport.Data;
using CoreReport.Models;
using CoreReport.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using AspNetCore.Reporting;
using System.Data.SqlClient;

namespace CoreReport.Controllers
{
    public class ReportingController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportingController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public ActionResult Index(ReportingViewModel model)
        {
            model.ReportingTreeViews = dbContext.Reportings.ToList();
            return View(model);
        }

        public ActionResult ReportView(ReportingViewModel model)
        {
            //string BankCode = PortalContext.CurrentUser.BankCode.Trim();

            //Select * from Reporting

            //Reporting reportingObj = _reportingManager.GetReportParameterBySlNo(model.SlNo) ?? new Reporting();
            Reporting reportingObj = dbContext.Reportings.Where(x => x.SlNo == model.SlNo).FirstOrDefault();
            model.ReportPath = reportingObj.ReportPath;
            model.Qryname = reportingObj.Qryname;
            model.xmlTableName = reportingObj.xmlTableName;
            model.ReportPath = reportingObj.ReportPath;
            model.ReportName = reportingObj.ReportName;
            model.Para1 = reportingObj.Para1;
            model.Para2 = reportingObj.Para2;
            model.Para3 = reportingObj.Para3;
            model.Para4 = reportingObj.Para4;
            if (!model.Para1.Equals("0"))
            {
                model.Parameters.Add(model.Para1, "");
            }
            if (!model.Para2.Equals("0"))
            {
                model.Parameters.Add(model.Para2, "");
            }
            if (!model.Para3.Equals("0"))
            {
                model.Parameters.Add(model.Para3, "");
            }
            if (!model.Para4.Equals("0"))
            {
                model.Parameters.Add(model.Para4, "");
            }
            model.SlNo = model.SlNo;
            return View(model);
        }

        public ActionResult AspReport(ReportingViewModel model)
        {
            var sessionUser = HttpContext.Session.GetString("paramertes");
            if (sessionUser == null)
            {
                HttpContext.Session.SetString("paramertes", JsonConvert.SerializeObject(model.Parameters));
                HttpContext.Session.SetString("slNo", JsonConvert.SerializeObject(model.SlNo));
            }
            return Redirect("~/Reports/TreeReportViwer.aspx");
        }

        public async Task<IActionResult> Print(ReportingViewModel model)
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\" + model.ReportPath;

            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Excel, extension, model.Parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }
    }
}

//string name = null;
//int? id = null;
//SqlParameter[] param = new SqlParameter[]{
//                new SqlParameter("@id",id??(object)DBNull.Value),
//                new SqlParameter("@name",name??(object)DBNull.Value)
//            };
//var data = dbContext.Database.q<PostDetail>("GetDataByIdName @id,@name", param).ToList();
//return View(data);