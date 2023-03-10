using DrawingApp.Hubs;

namespace DrawingApp
{
    public class Program
    {
        // TODO: rename script.js to something with draw in name
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services
                .AddSignalR()
                .AddJsonProtocol(options => { options.PayloadSerializerOptions.PropertyNamingPolicy = null; });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapHub<DrawHub>("/drawHub");

            app.Run();
        }
    }
}