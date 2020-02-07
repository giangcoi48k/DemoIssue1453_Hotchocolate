using DemoIssue1453_Ver10_3_5.Models;
using HotChocolate.Types;

namespace DemoIssue1453_Ver10_3_5.Schemas
{
    public class Query : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("companyReports")
                .Type<CompanyReportType>()
                .Resolver(ctx =>
                {
                    return new CompanyReport
                    {
                        OrganCode = "Test",
                    };
                });
        }
    }
}
