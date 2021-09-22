// <copyright file="Startup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using AspNetSandbox.Data;
    using AspNetSandbox.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(GetConnectionString()));

                    // Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiSandbox", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
            services.AddSignalR();
            services.AddScoped<IBookRepository, DbBookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiSandbox v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            var defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames = new List<string>();

            defaultFilesOptions.DefaultFileNames.Add("index-old.html");
            app.UseDefaultFiles(defaultFilesOptions);

            app.UseStaticFiles();

            app.SeedData();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<MessageHub>("/messagehub");
            });
        }

        public static string ConvertConnectionString(string connectionstring)
        {
            Uri uri = new Uri(connectionstring);
            var databasename = $"AbsolutePath:{uri.AbsolutePath}";
            var hostname = $"Host: {uri.Host}";
            var portname = $"Port: {uri.Port}";
            var username = $"UserInfo: {uri.UserInfo}";
            var urlString = "Database = " + databasename.Split("/")[1] + "; Host =" + hostname.Split(":")[1].Replace("-", " - ") + "; Port =" + portname.Split(":")[1] + "; User Id =" + username.Split(":")[1] + "; Password = " + username.Split(":")[2] + "; SSL Mode = Require; Trust Server Certificate = true";

            return urlString;
        }

        private string GetConnectionString()
        {
            var connectionstring = Environment.GetEnvironmentVariable("DATABASE_URL");
            if (connectionstring != null)
            {
                return ConvertConnectionString(connectionstring);
            }

            return Configuration.GetConnectionString("NewDefaultConnection");
        }
    }
}
