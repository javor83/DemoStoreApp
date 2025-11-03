using RestoreApp.Interface;
using RestoreApp.Services;

using RestoreApp.LocalDbStore;

namespace RestoreApp
{
    public class Program
    {
        /*

        ok
        Scaffold-DbContext "Server=DESKTOP-H09IM5N;Database=SportsStore;Trusted_Connection=True;TrustServerCertificate=True;  " Microsoft.EntityFrameworkCore.SqlServer -OutputDir LocalDbStore -force
       */
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var app_db = builder.Configuration.GetConnectionString("app_db");
            builder.Services.AddSqlServer<SportsStoreContext>(app_db);
            //builder.Services.AddDbContext<SportsStoreContext>(options => {options.UseSqlServer(app_db);});
            builder.Services.AddTransient<ICategory, ServiceCategory>();
            builder.Services.AddTransient<IProduct, ServiceProduct>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
