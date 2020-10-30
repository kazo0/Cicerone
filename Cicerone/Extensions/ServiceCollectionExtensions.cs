using Cicerone.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using Cicerone.Views;

namespace Cicerone.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddViewModels(this IServiceCollection services)
		{
			services.AddAllSubclassesOf<BaseViewModel>(typeof(BaseViewModel).Assembly);
		}

		public static void AddPages(this IServiceCollection services)
		{
			services.AddAllSubclassesOf<Page>(typeof(AppShell).Assembly);
		}

		public static void AddAllSubclassesOf<T>(
			this IServiceCollection services,
			Assembly assembly,
			ServiceLifetime lifetime = ServiceLifetime.Transient)
		{
			var types = assembly
				.DefinedTypes
				.Where(t => t.IsSubclassOf(typeof(T)) &&
							!t.IsAbstract);

			foreach (var type in types)
			{
				services.Add(new ServiceDescriptor(type.AsType(), type.AsType(), lifetime));
			}
		}
	}
}
