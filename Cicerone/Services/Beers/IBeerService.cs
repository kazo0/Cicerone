using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cicerone.Models;

namespace Cicerone.Services.Beers
{
	public interface IBeerService
	{
		Task<List<Beer>> SearchBeer(string searchTerm);
	}
}
