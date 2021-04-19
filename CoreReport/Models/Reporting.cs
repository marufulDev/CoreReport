using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreReport.Models
{
    public class Reporting
    {
        public List<Reporting> ReportingTrees = new List<Reporting>();

        public Reporting()
        {
            ReportingTrees = new List<Reporting>();
        }

        [Key]
        public string SlNo { get; set; }

        public string ReportName { get; set; }
        public string ReportPath { get; set; }
        public string QryType { get; set; }
        public string Qryname { get; set; }
        public string xmlTableName { get; set; }
        public string Para1 { get; set; }
        public string Para2 { get; set; }
        public string Para3 { get; set; }
        public string Para4 { get; set; }
        public bool MultipleReport { get; set; }
        public string ReportLevel { get; set; }
        public string FirstLevel { get; set; }
        public string SecondLevel { get; set; }
        public string ThirdLevel { get; set; }
        public bool IsEventLog { get; set; }
        public string UserId { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}