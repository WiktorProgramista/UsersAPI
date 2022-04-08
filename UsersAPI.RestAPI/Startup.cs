using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserAPI.Application.Implementations;
using UserAPI.Application.Interfaces;

namespace UsersAPI.RestAPI
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 

                    Title = "Swagger",
                    Description = "Swagger", 
                    Version = "v1",

                });

            });
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDbConnector, DbConnector>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();

                
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => {


                options.SwaggerEndpoint("/swagger/v1/swagger.json", "UsersAPI");
            });
        }
    }
}
