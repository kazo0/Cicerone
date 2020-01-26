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
using System.Linq;

namespace Cicerone.Core.ViewModels
{
	public class SearchViewModel : BaseViewModel
	{
		private const int PageSize = 25;

		private readonly IBeerService _beerService;
		private readonly IMvxNavigationService _navigationService;

		private string _currentQuery;
		private int _page;
		private BeerSearchResponse _searchResponse;

		private ICommand _searchCommand;
		public ICommand SearchCommand =>
			_searchCommand ?? (_searchCommand = new MvxAsyncCommand<string>(Search, _ => true, true));

		private ICommand _refreshCommand;
		public ICommand RefreshCommand =>
			_refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(Refresh));

		private ICommand _selectBeerCommand;
		public ICommand SelectBeerCommand =>
			_selectBeerCommand ?? (_selectBeerCommand = new MvxAsyncCommand<BeerSummary>(NavigateToBeerDetails));

		private ICommand _thresholdReachedCommand;
		public ICommand ThresholdReachedCommand =>
			_thresholdReachedCommand ?? (_thresholdReachedCommand = new MvxAsyncCommand(LoadNextPage));

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

		private int _itemThreshold;
		public int ItemTreshold
		{
			get { return _itemThreshold; }
			set { SetProperty(ref _itemThreshold, value); }
		}

		public SearchViewModel(IBeerService beerService, IMvxNavigationService navigationService)
		{
			_beerService = beerService;
			_navigationService = navigationService;

			_itemThreshold = 5;
		}

		private async Task Search(string query)
		{
			if (IsBusy)
			{
				return;
			}

			IsBusy = true;
			_page = 0;
			ItemTreshold = 0;
			_currentQuery = query;
			_searchResponse = await _beerService.GetBeers(query);

			var beers = _searchResponse?.Beers
				?.BeerItems
				?.Select(x => x.Beer) ?? Enumerable.Empty<BeerSummary>();

			Beers = new ObservableCollection<BeerSummary>(beers);

			IsBusy = false;
		}

		private async Task Refresh()
		{
			await Search(_currentQuery);
		}

		private async Task NavigateToBeerDetails(BeerSummary beer)
		{
			await _navigationService.Navigate<BeerDetailsViewModel, long>(beer.Bid);
		}

		private async Task LoadNextPage()
		{

			var offset = ++_page * PageSize;
			var beerSearchResponse = await _beerService.GetBeers(_currentQuery, offset);


			var beers = beerSearchResponse?.Beers
				?.BeerItems
				?.Select(x => x.Beer) ?? Enumerable.Empty<BeerSummary>();

			if (!beers.Any())
			{
				ItemTreshold = -1;
			}

			foreach (var beer in beers)
			{
				Beers.Add(beer);
			}
		}
	}
}
