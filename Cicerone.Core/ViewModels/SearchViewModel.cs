using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Cicerone.Core.Services.Beers;
using System.Collections.Generic;
using Cicerone.Core.Models;
using System.Linq;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using System.Net.Http;

namespace Cicerone.Core.ViewModels
{
	public class SearchViewModel : BaseViewModel
	{
		private const int PageSize = 25;

		private readonly IBeerService _beerService;

		private string _currentQuery;
		private int _page;
		private BeerSearchResponse _searchResponse;

		public ICommand SearchCommand => new AsyncCommand<string>(Search);
		public ICommand RefreshCommand => new AsyncCommand(Refresh);
		public ICommand SelectBeerCommand => new MvvmHelpers.Commands.Command<BeerSummary>(NavigateToBeerDetails);
		public ICommand ThresholdReachedCommand =>  new AsyncCommand(LoadNextPage);

		public ObservableCollection<BeerSummary> Beers { get; set; }
		public BeerSummary SelectedBeer { get; set; }
		public int ItemTreshold { get; set; }

		public SearchViewModel(IBeerService beerService)
		{
			_beerService = beerService;

			ItemTreshold = 5;
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

		private void NavigateToBeerDetails(BeerSummary beer)
		{
			MessagingCenter.Send<SearchViewModel, long>(this, "Navigate", beer.Bid);
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

		public override async Task Initialize()
		{
		}
	}
}
