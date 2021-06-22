using Cloud.PPATSApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Cloud.PPATSApp.Models.CloudPATContext;

namespace Cloud.PPATSApp
{
    public class Startup
    {
        public static string ConnectionString { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var connection = @"Data Source=DESKTOP-9CRJRHJ\SS17;Initial Catalog=CloudPAT;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=sa";
            //ConnectionString = Configuration.Get<string>(connection);

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //direct connection string - Method 1
            var connection = @"Data Source=DESKTOP-9CRJRHJ\SS17;Initial Catalog=CloudPAT;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=sa";
            services.AddDbContext<CloudPATContext>(options => options.UseSqlServer(connection));

            //from app settings json - Method 2
            services.AddDbContext<CloudPATContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //from external file dataSettings .json - Method3
            //var settings = new DataSettingsManager().LoadSettings(); //Check dataasettings in dbcontenxt file
            //var dbConnection = settings.DataConnectionString.ToString();
            //services.AddDbContext<CloudPATContext>(options => options.UseSqlServer(dbConnection));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
