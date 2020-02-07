using DemoIssue1453_Ver10_2_0.Models;
using HotChocolate.Types;

namespace DemoIssue1453_Ver10_2_0.Schemas
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
