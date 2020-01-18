using System;
using Cicerone.Core.Clients.Untappd;
using Cicerone.Core.Services.Beers;
using Cicerone.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using RestSharp;

namespace Cicerone.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			base.Initialize();

			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			CreatableTypes()
				.EndingWith("Client")
				.AsInterfaces()
				.RegisterAsLazySingleton();


			Mvx.IoCProvider.RegisterType<IRestClient, RestClient>();

			RegisterAppStart<SearchViewModel>();
		}
	}
}