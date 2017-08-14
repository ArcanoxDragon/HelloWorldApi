using HelloWorldApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HelloWorldApi
{
	public class Startup
	{
		public Startup( IHostingEnvironment env )
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath( env.ContentRootPath )
				.AddJsonFile( "appsettings.json", optional: false, reloadOnChange: true )
				.AddJsonFile( $"appsettings.{env.EnvironmentName}.json", optional: true )
				.AddEnvironmentVariables();

			this.Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices( IServiceCollection services )
		{
			// Add framework services.
			services.AddMvc();

			// Add API services
			services.AddSingleton<IWriteService, ResponseWriteService>( ctx => new ResponseWriteService( this.Configuration ) );
		}

		public void Configure( IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory )
		{
			loggerFactory.AddConsole( this.Configuration.GetSection( "Logging" ) );
			loggerFactory.AddDebug();

			app.UseMvc();
		}
	}
}