using Cicerone.Core.Clients.Untappd;
using Cicerone.Core.Services.Beers;
using Cicerone.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cicerone
{

	public static class Startup
	{
		public static IServiceProvider ServiceProvider { get; set; }

		public static void Init()
		{

			var host = Host.CreateDefaultBuilder()
				.ConfigureAppConfiguration(config =>
				{
					config.SetFileProvider(new EmbeddedFileProvider(typeof(App).Assembly));
				})
				.ConfigureServices(ConfigureServices)
				.ConfigureLogging(builder =>
				{
					builder.AddConsole();
				})
				.Build();

			ServiceProvider = host.Services;
		}

		private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
		{
			services.AddTransient<IRestClient, RestClient>();
			services.AddTransient<IUntappdClient, UntappdClient>();
			services.AddTransient<IBeerService, BeerService>();

			services.AddViewModels();
			services.AddPages();
		}
	}
}
