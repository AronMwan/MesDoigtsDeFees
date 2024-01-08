using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MesDoigtsDeFees.Data;
using Microsoft.AspNetCore.Identity;
using MesDoigtsDeFees.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using MesDoigtsDeFees.Services;
using NETCore.MailKit.Infrastructure.Internal;
using Microsoft.OpenApi.Models;

namespace MesDoigtsDeFees
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("MesDoigtsDeFeesContext");

            builder.Services.AddDbContext<MyDBContext>(options =>
                options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'MesDoigtsDeFeesContext' not found.")));

            builder.Services.AddDefaultIdentity<MesDoigtsDeFeesUser>((IdentityOptions options) => options.SignIn.RequireConfirmedAccount = false)
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<MyDBContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IEmailSender, MailKitEmailSender>();

            // De volgende configuratie van de MailKit wordt toegevoegd als demonstratie, maar gebruiken we niet.
            // Deze is "overschreven" door het gebruik van de database-parameters in Globals, en ge?nitialiseerd in de data Initializer
            builder.Services.Configure<MailKitOptions>(options =>
            {
                options.Server = builder.Configuration["ExternalProviders:MailKit:SMTP:Address"];
                options.Port = Convert.ToInt32(builder.Configuration["ExternalProviders:MailKit:SMTP:Port"]);
                options.Account = builder.Configuration["ExternalProviders:MailKit:SMTP:Account"];
                options.Password = builder.Configuration["ExternalProviders:MailKit:SMTP:Password"];
                options.SenderEmail = builder.Configuration["ExternalProviders:MailKit:SMTP:SenderEmail"];
                options.SenderName = builder.Configuration["ExternalProviders:MailKit:SMTP:SenderName"];
                options.Security = true;  // true zet ssl or tls aan
            });

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "MesDoigtsDeFees", Version = "v1" });
            });


            var app = builder.Build();
            Globals.App = app;
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MesDoigtsDeFees v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();



            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                MyDBContext context = new MyDBContext(services.GetRequiredService<DbContextOptions<MyDBContext>>());
                var userManager = services.GetRequiredService<UserManager<MesDoigtsDeFeesUser>>();
                await MyDBContext.DataInitializer(context, userManager);
            }

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}