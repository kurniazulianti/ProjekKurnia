using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjekKurnia.Data;
using ProjekKurnia.Models;
using ProjekKurnia.Repositories.AkunRepository;
using ProjekKurnia.Repositories.DepartemenRepository;
using ProjekKurnia.Repositories.DokterRepository;
using ProjekKurnia.Repositories.InapRepository;
using ProjekKurnia.Repositories.JalanRepository;
using ProjekKurnia.Repositories.PasienRepository;
using ProjekKurnia.Services;
using ProjekKurnia.Services.AkunService;
using ProjekKurnia.Services.DepartemenService;
using ProjekKurnia.Services.DokterService;
using ProjekKurnia.Services.InapService;
using ProjekKurnia.Services.JalanService;
using ProjekKurnia.Services.PasienService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia
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
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySQL(Configuration.GetConnectionString("mysql"));
            });

            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Akun/Masuk";
                }
            );

            // daftarkan repo dan service disini
            // repository
            services.AddScoped<IDepartemenRepository, DepartemenRepository>();
            services.AddScoped<IPasienRepository, PasienRepository>();
            services.AddScoped<IDokterRepository, DokterRepository>();
            services.AddScoped<IJalanRepository, JalanRepository>();
            services.AddScoped<IAkunRepository, AkunRepository>();
            services.AddScoped<IInapRepository, InapRepository>();

            // service
            services.AddScoped<IDepartemenService, DepartemenService>();
            services.AddScoped<IPasienService, PasienService>();
            services.AddScoped<IDokterService, DokterService>();
            services.AddScoped<IJalanService, JalanService>();
            services.AddScoped<IAkunService, AkunService>();
            services.AddScoped<IInapService, InapService>();

            // ambil data dari appsetting.json, dan set datanya di Models/Email
            services.Configure<Email>(Configuration.GetSection("AturEmail"));

            // daftarkan fileService
            services.AddTransient<FileService>();
            services.AddTransient<EmailService>();

            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "AreaAdmin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapAreaControllerRoute(
                    name: "AreaUser",
                    areaName: "User",
                    pattern: "User/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Akun}/{action=Masuk}/{id?}");
            });
        }
    }
}
