using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using TradingPlatform.Infrastructure.BackgroundServices.Implementations;
using TradingPlatform.Infrastructure.BackgroundServices.Interfaces;
using TradingPlatform.Infrastructure.Configuration;
using TradingPlatform.Infrastructure.Middlewares;
using TradingPlatform.Infrastructure.Services.Implementations;
using TradingPlatform.Infrastructure.Services.Interfaces;
using TradingPlatform.Models;
using TradingPlatform.Repositories;

namespace TradingPlatform
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

            services.AddDbContext<TradingPlatformContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("TradingPlatformDBConnectionAzureSQL"))
            .UseLazyLoadingProxies());

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TradingPlatformContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddControllersWithViews();

            services.AddHttpContextAccessor();

            services.AddScoped<IUserRepository, SqlUserRepository>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IItemRepository, SqlItemRepository>();

            services.AddScoped<ICountriesRepository, SqlCountriesRepository>();

            services.AddScoped<ICategoryRepository, SqlCategoryRepository>();

            services.AddScoped<IOrderRepository, SqlOrderRepository>();

            services.AddScoped<IServiceRestClient, ServiceRestClient>();

            services.AddScoped<ISynchroniseCurrencyRate, SynchroniseCurrencyRate>();

            services.AddScoped<IMessageService, MessageService>();

            services.AddSingleton<IMessageService, MessageService>();

            /*services.AddHostedService<SyncCurrencyRateBackgroundService>();*/ // commented due to API requests qty limitations

            var servicesConfiguration = Configuration.GetSection("TradingPlatform");
            services.Configure<TradingPlatformConfiguration>(servicesConfiguration);
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
            app.UseFileServer();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024
            };
            app.UseWebSockets(webSocketOptions);

            app.UseMiddleware<ChatMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
