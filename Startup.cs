using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo4EmpDisplay.Services;
using Demo4EmpDisplay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;



namespace Demo4EmpDisplay
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //5.  Use MVC services
            services.AddMvc(options => options.EnableEndpointRouting = false);

            //6.  Use mvc default route 


            //30.  Create IFormatNumber Interface and FormatNumber Class
            //31.  Go to Interface
            //38.  Use singleton for FormatNumber
            services.AddSingleton<IFormatNumber, FormatNumber>();
            //39.  Go to Home Index Page

            //49.  Create _ViewImports(The "_" is important as it is a convention) view in Views Folder for TagHelper

            //54.  Lets Begin Partial View
            //55.  Create a Shared Folder in Views Folder
            //56.  Add Razer (_Name) partial view, make sure to check the box "Partial View"
            //57.  Go to _FirstPartial page


            //66.  Go to EmployeeController to start pulling images for employee

            //72.  Create a Model Folder and add Employee Class
            //73.  Go to Employee Class


            //101.  Add services for Employees (Interface and Class)
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            //102.  Go to Employee Controller

            //159.  Add a DB Context Class in Models Folder
            //160.  Add Nuget Package to use DB, EntityFramework Core
            //161.  Go to EmployeeContext Class

            //168.  Add Nuget Package Microsoft.EntityFrameworkCore.Sqlite
            //168a.  Add DBContext into your services, use the class where the codes was at, then use SQLite provider, and give db a name
            //services.AddDbContext<EmployeeContext>(options => options.UseSqlite("Data Source = Employee.db"));
            //**Notes** If you want to use SqlServer, download nuget package and change provider
            //169.  Go to Configure Method and pass the employee context variable to the pipeline

            //185.  Comment out MockRepository in Line 52 and use DBRepository to prevent conflict
            services.AddScoped<IEmployeeRepository, DBRepository>();

            //186.  Create a class in Models call "Department"
            //187.  Go to Department Class to set relation between dept and employees (1 to many : dept to emp)



            //197.  Comment out UseSqlite provider so we can use sqlserver
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer("Server=DESKTOP-URUP0KQ;Database=DispEmp;Trusted_Connection=true;MultipleActiveResultSets=true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EmployeeContext employeeContext) //170.  Add the method here
        {
            //198.  activate the ensuredeleted method 
            employeeContext.Database.EnsureDeleted();
            //199.  Go to DBRepository to add departmentclass

            //171.  Ensure the db is created
            employeeContext.Database.EnsureCreated();
            //172.  Add a db repository class in Services to use CRUD
            //173.  Go to DBRepository Class



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //7.  MVC Default
            app.UseMvcWithDefaultRoute();

            //8.  Use Static Files
            app.UseStaticFiles();
            //9.  Create EmployeeController
            //10.  Create Employee Folder in Views
            //11.  Create Employee Index Page
            //12.  Go to EmployeeController




            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
