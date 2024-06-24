using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StaffManagement.Models;
using StaffManegement.DataAccess;
using StaffManegement.DataAccess.Models;


namespace StaffManagement
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<IStaffRepository, SqlserverStaffRepository>();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("StaffDb")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }


            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
