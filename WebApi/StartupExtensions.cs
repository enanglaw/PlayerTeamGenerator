using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.Helpers;

namespace WebApi
{


    public static class StartupExtensions
    {
    
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Course Tech Interview API");
                });
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Add Error Page
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            return app;

        }
      


    }
}