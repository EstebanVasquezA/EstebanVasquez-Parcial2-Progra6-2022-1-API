using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using EstebanVasquez_Parcial2_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EstebanVasquez_Parcial2_API
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

            services.AddControllers();

            var conn = @"SERVER=.;DATABASE=EXAMEN_FINAL_PROGRA6;Trusted_Connection=True;";

            services.AddDbContext<EXAMEN_FINAL_PROGRA6Context>(options => options.UseSqlServer(conn));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EstebanVasquez-Parcial2-API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstebanVasquez-Parcial2-API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
