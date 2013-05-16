using System;
using System.Collections.Generic;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	public class WebAPILocation
	{
		private static readonly List<WebAPILocation> Environments = new List<WebAPILocation>
		{
			new WebAPILocation(WebAPIEnvironment.SIM, new Uri("https://sim.api.tradestation.com")), 
			new WebAPILocation(WebAPIEnvironment.Live, new Uri("https://api.tradestation.com"))
		};

		public static List<WebAPILocation> WebAPIEnvironments { get { return Environments; } }

		public WebAPIEnvironment Name { get; set; }
		public Uri Location { get; set; }

		public WebAPILocation(WebAPIEnvironment name, Uri location)
		{
			Name = name; 
			Location = location; 
		}

	}
}
