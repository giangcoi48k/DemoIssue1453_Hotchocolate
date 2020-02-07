using DemoIssue1453_Ver10_3_5.Models;
using HotChocolate.Types;
using System.Collections.Generic;

namespace DemoIssue1453_Ver10_3_5.Schemas
{
    public class CompanyReportType : ObjectType<CompanyReport>
    {
        protected override void Configure(IObjectTypeDescriptor<CompanyReport> descriptor)
        {
            descriptor.Ignore(t => t.FsItems);

            descriptor.Field("fsItems")
                .Type<ListType<ObjectType<FsItem2>>>()
                .Resolver(ctx =>
                {
                    return new List<FsItem2>
                    {
                        new FsItem2
                        {
                            Key = "Key",
                            Value = 100
                        }
                    };
                });
        }
    }
}
