using System;
using System.Globalization;
using Cicerone.Core.Models;
using Xamarin.Forms;

namespace Cicerone.Converters
{
	public class BeerToLabelConverter : IValueConverter
	{ 
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is BeerDetail beer))
			{
				return null;
			}
			return !string.IsNullOrWhiteSpace(beer.BeerLabelHd) ? beer.BeerLabelHd : beer.BeerLabel;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
