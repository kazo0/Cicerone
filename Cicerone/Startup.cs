using System;
using Cicerone.Clients.Untappd;
using Cicerone.Services.Beer;
using Cicerone.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Cicerone
{
	public static class Startup
	{
		public static IServiceProvider ServiceProvider { get; set; }

		public static void Init()
		{
			var host = new HostBuilder()
				.ConfigureServices((ctx, services) =>
				{
					ConfigureServices(ctx, services);
				})
				.ConfigureLogging((log) =>
				{
					log.AddConsole(b =>
					{
						b.DisableColors = true;
					});
				})
				.Build();

            ServiceProvider = host.Services;
        }

		private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
		{
			services.AddTransient<SearchViewModel>();
			services.AddSingleton<IBeerService, BeerService>();
			services.AddSingleton<IUntappdClient, UntappdClient>();
			services.AddSingleton<IRestClient, RestClient>();
		}

	}
}
