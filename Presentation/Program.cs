
using StockApp.Application;
using StockApp.Core;
using StockApp.Infrastructure;
using StockApp.WebUI.Middlewares;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            string relativePath = Path.Combine("..", "Infrastructure", "Data", "Chatbot - stock data.json");
            string infrastructurePath = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, relativePath));

            builder.Services.AddSingleton<IStockRepository>(sp =>
                new StockRepository(infrastructurePath, sp.GetRequiredService<ILogger<StockRepository>>()));
            builder.Services.AddScoped<IGetStocksByExchangeUseCase, GetStocksByExchangeUseCase>();
            builder.Services.AddScoped<IGetStockDetailsUseCase, GetStockDetailsUseCase>();

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Stock}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
