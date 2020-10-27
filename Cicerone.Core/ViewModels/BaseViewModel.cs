using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cicerone.Core.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public bool IsBusy { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public abstract Task Initialize();
	}
}
