using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wiz_Film_Search.Service;
using Wiz_Film_Search.Services;
using Refit;
using Wiz_Film_Search.Middleware;

namespace Wiz_Film_Search
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

            services.AddHttpClient();
            services.AddRefitClient<ITheMoviedb>()
                   .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration["MoviesApi:Url"]));
            services.AddSingleton(typeof(IMovieService), typeof(MovieService));
            services.AddSingleton(typeof(ITokenRepoService), typeof(TokenRepoService));
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.ApplyApiKeyValidation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
