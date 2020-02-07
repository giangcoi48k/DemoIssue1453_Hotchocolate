using System.Collections.Generic;

namespace DemoIssue1453_Ver10_2_0.Models
{
    public class CompanyReport
    {
        public string OrganCode { get; set; }
        public IEnumerable<FsItem> FsItems { get; set; }
    }
}
