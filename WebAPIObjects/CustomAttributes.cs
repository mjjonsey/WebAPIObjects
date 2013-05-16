using System;

namespace TradeStation.SystemTeam.Tools.WebAPI.WebAPIObjects
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	public sealed class InitialVersionAttribute : Attribute
	{
		public InitialVersionAttribute(WebApiVersion initialVersion) 
		{
			InitialVersion = initialVersion;
		}

		public WebApiVersion InitialVersion { get; private set; }

	}

	public enum WebApiVersion 
	{
		V1, 
		V2, 
		V21, 
		V3
	}
	
}
