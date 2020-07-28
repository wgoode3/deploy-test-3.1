using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttemptOne.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AttemptOne
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {
            // services.AddSession ();
            services.AddDbContext<MyContext> (o => o.UseMySql (Configuration["DBInfo:ConnectionString"]));
            services.AddControllersWithViews ();
            services.AddMvc (option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseSession ();
            app.UseDeveloperExceptionPage ();
            app.UseStaticFiles ();
            app.UseMvc ();
        }
    }
}