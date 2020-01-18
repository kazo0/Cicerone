using System;
using System.Collections.Generic;
using Cicerone.Core.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace Cicerone.Views
{
	public partial class BeerDetailsPage : MvxContentPage<BeerDetailsViewModel>
	{
		public BeerDetailsPage()
		{
			InitializeComponent();
		}
	}
}
