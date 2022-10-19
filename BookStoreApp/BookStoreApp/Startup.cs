using BusinessObject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp
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
            services.AddDbContext<BookStoreDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSession();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IPublisherRepository, PublisherRepository>();

            services.AddScoped<IStoreRepository, StoreRepository>();

            services.AddScoped<IBookInStoreRepository, BookInStoreRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
            }

            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
