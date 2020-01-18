using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cicerone.Services.Beer;
using Xamarin.Forms;

namespace Cicerone.ViewModels
{
	public class SearchViewModel
	{
		private Command<string> _searchCommand;
		private readonly IBeerService _beerService;

		public Command<string> SearchCommand =>
			_searchCommand ?? (_searchCommand = new Command<string>(async (q) => await Search(q)));


		public SearchViewModel(IBeerService beerService)
		{
			_beerService = beerService;
		}

		private async Task Search(string query)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return;
			}

			var beers = await _beerService.SearchBeer(query);
			
		}
	}
}
