using ClickerGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace Clicker
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=clicker.db"));

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Clicker}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
