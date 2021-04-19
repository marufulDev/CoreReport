using CoreReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreReport.ViewModels
{
    public class ReportingViewModel : Reporting
    {
        public List<Reporting> ReportingTreeViews { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
        public string ReportName { get; set; }

        public ReportingViewModel()
        {
            ReportingTreeViews = new List<Reporting>();
            Parameters = new Dictionary<string, string>();
        }

        //public IEnumerable<SelectListItem> ExchangeCompanyListItem
        //{
        //    get { return new SelectList(ExchangeCompany, "BranchCode", "BranchName"); }
        //}

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}