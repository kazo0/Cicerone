using System;
using MvvmCross.ViewModels;

namespace Cicerone.Core.ViewModels
{
	public abstract class BaseViewModel : MvxViewModel
	{
		private bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}
	}

	public abstract class BaseViewModel<T> : BaseViewModel, IMvxViewModel<T>
	{
		public abstract void Prepare(T parameter);
	}
}
