using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using UiB.Domain.WorkShifts;
using UiB.MySql.WorkShifts;

namespace UiB.API
{
    public class Startup
    {
        private readonly Container _container = new Container();
        private Settings Settings { get; set; }

        public Startup()
        {
            Settings = new Settings(new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build());
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "UiB API",
                Description = "A small Time Registration System API"
            }));

            services.AddSimpleInjector(_container, options => options.AddAspNetCore().AddControllerActivation());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(_container);
            _container.RegisterInstance(Settings);

            _container.Register<IWorkShiftRepository, WorkShiftRepository>();
            _container.Register<IWorkShiftService, WorkShiftService>();

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UiB API V1");
                c.RoutePrefix = string.Empty;
                c.InjectStylesheet("/swagger-ui/custom.css");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}