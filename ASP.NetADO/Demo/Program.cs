using System.Net.NetworkInformation;

namespace WebApplication1

{

    public class Program

    {

        public static void Main(string[] args)

        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())

            {

                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

                app.UseHsts();

            }

            app.UseHttpsRedirection(); // Redirects all HTTP ? HTTPS  

            app.UseStaticFiles();// Serves static files (CSS, JS, images, etc.)  

            app.UseRouting();// Enables routing system (builds route table)

            app.UseAuthorization(); // Checks authorization policies if applied

            // Defining Route Pattern

            // convention-based route

            app.MapControllerRoute(

                name: "default",

                // if no controller is given in the URL, default = HomeController

                // {action=Index} ? if no action is given, default = Index() method

                // {id?} ? optional parameter (can be passed or skipped)

                pattern: "{controller=Home}/{action=Index}/{id?}"
                
                );

          
            app.MapControllerRoute(
                name: "testing",
                pattern: "{controller=Home}/{action=Testing}/{id?}"
            );


            app.Run();

        }

    }

}
