using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace xChanger.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration) =>
			Configuration = configuration;

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var openApiInfo = new OpenApiInfo
			{
				Title = "xChanger.Api",
				Version = "v1"
			};

			services.AddControllers();

			services.AddSwaggerGen(config =>
			{
				config.SwaggerDoc(
					name:"v1",
				    info:  openApiInfo );
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment enveriment)
		{
			if (enveriment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();

				app.UseSwaggerUI(config => 
				config.SwaggerEndpoint(
					url:"/swagger/v1/swagger.json",
					name:"xChanger.Api v1"));
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
				endpoints.MapControllers());
		}
	}
}
