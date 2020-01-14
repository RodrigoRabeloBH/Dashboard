using APIDashboard.Data;
using APIDashboard.Data.Interfaces;
using APIDashboard.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIDashboard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<DataContext, DataContext>();
            services.AddScoped<ICustomer, CustomerRepository>();
            services.AddScoped<IServer, ServerRepository>();
            services.AddScoped<IOrder, OrderRepository>();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<SeedDB>();
            services.AddCors(opt => opt.AddPolicy("CorsPolicy", c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedDB seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CorsPolicy");
            }
            else
            {
                app.UseHsts();
            }

            seed.SeedData(20, 100);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
