using DemoIssue1453_Ver10_3_5.Schemas;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoIssue1453_Ver10_3_5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddGraphQL(sp => SchemaBuilder.New()
                    .AddServices(sp)
                    .AddAuthorizeDirectiveType()
                    .AddQueryType<Query>()
                    .AddType<CompanyReportType>()
                    .Create()
                , new QueryExecutionOptions
                {
                    TracingPreference = TracingPreference.OnDemand
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app
                .UseWebSockets()
                .UseGraphQL("/graphql")
                .UseGraphiQL("/graphql")
                .UsePlayground("/graphql")
                .UseVoyager("/graphql");
        }
    }
}
