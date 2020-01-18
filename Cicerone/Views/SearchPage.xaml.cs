using System;
using System.Collections.Generic;
using Cicerone.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace Cicerone.Views
{
	public partial class SearchPage : ContentPage
	{
		public SearchPage()
		{
			
			InitializeComponent();
			BindingContext = Startup.ServiceProvider.GetService<SearchViewModel>();
		}
	}
}
