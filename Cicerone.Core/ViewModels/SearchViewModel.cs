using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Cicerone.Core.Services.Beers;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using System.Collections.Generic;
using Cicerone.Core.Models;
using MvvmCross.Navigation;

namespace Cicerone.Core.ViewModels
{
	public class SearchViewModel : BaseViewModel
	{
		private readonly IBeerService _beerService;
		private readonly IMvxNavigationService _navigationService;

		private string _currentQuery;

		private ICommand _searchCommand;
		public ICommand SearchCommand =>
			_searchCommand ?? (_searchCommand = new MvxAsyncCommand<string>(Search));

		private ICommand _refreshCommand;
		public ICommand RefreshCommand =>
			_refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(Refresh));

		private ICommand _selectBeerCommand;
		public ICommand SelectBeerCommand =>
			_selectBeerCommand ?? (_selectBeerCommand = new MvxAsyncCommand(NavigateToBeerDetails));

		private ObservableCollection<BeerSummary> _beers;
		public ObservableCollection<BeerSummary> Beers
		{
			get => _beers;
			set => SetProperty(ref _beers, value);
		}

		private BeerSummary _selectedBeer;
		public BeerSummary SelectedBeer
		{
			get => _selectedBeer;
			set => SetProperty(ref _selectedBeer, value);
		}

		public SearchViewModel(IBeerService beerService, IMvxNavigationService navigationService)
		{
			_beerService = beerService;
			_navigationService = navigationService;
		}

		private async Task Search(string query)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return;
			}

			IsBusy = true;

			_currentQuery = query;
			var beers = await _beerService.GetBeers(query);
			Beers = new ObservableCollection<BeerSummary>(beers);

			IsBusy = false;
		}

		private async Task Refresh()
		{
			await Search(_currentQuery);
		}

		private async Task NavigateToBeerDetails()
		{
			await _navigationService.Navigate<BeerDetailsViewModel, long>(SelectedBeer.Bid);
		}
	}
}
