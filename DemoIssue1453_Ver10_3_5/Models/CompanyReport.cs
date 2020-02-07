using System.Collections.Generic;

namespace DemoIssue1453_Ver10_3_5.Models
{
    public class CompanyReport
    {
        public string OrganCode { get; set; }
        public IEnumerable<FsItem> FsItems { get; set; }
    }
}
