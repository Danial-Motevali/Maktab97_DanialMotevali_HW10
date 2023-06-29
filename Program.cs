using hw10.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace hw10
{
    public class Program
    {
        static List<Log> logs;

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.Use( async(context, next) =>
            {
                var j = JsonConvert.SerializeObject(logs, Formatting.Indented);

                File.AppendAllText(@"C:\Users\mutool\Desktop\HW\hw10\hh.txt", j);

                await next();
            });

            app.Run();
        }
    }
}