﻿using System;
using Newtonsoft.Json;

namespace Cicerone.Models
{
	public class BaseResponse<T> where T : class
	{
		[JsonProperty("response")]
		public T Response { get; set; }
	}
}
