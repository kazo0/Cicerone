using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cicerone.ViewModels
{
	public class SearchViewModel
	{
		private Command<string> _searchCommand;
		public Command<string> SearchCommand =>
			_searchCommand ?? (_searchCommand = new Command<string>(async (q) => await Search(q)));

		public SearchViewModel()
		{
		}

		private async Task Search(string query)
		{
			
			await Task.Delay(3000);
		}
	}
}
