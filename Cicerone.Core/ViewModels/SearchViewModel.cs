using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Cicerone.Core.Services.Beers;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using System.Collections.Generic;
using Cicerone.Core.Models;

namespace Cicerone.Core.ViewModels
{
	public class SearchViewModel : MvxViewModel
	{
		private readonly IBeerService _beerService;

		private ICommand _searchCommand;
		public ICommand SearchCommand =>
			_searchCommand ?? (_searchCommand = new MvxAsyncCommand<string>(Search));

		private ObservableCollection<Beer> _beers;
		public ObservableCollection<Beer> Beers
		{
			get => _beers;
			set => SetProperty(ref _beers, value);
		}



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
			Beers = new ObservableCollection<Beer>(beers);
		}
	}
}
