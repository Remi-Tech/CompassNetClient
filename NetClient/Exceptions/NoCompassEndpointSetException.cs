using System;
namespace Compass.Net.Client.Exceptions
{
	public class NoCompassEndpointSetException : Exception
	{
		public NoCompassEndpointSetException(string eventName)
			: base($"Compass endpoint not set in configuration: {eventName}.")
		{
		}

		public NoCompassEndpointSetException()
	        : base($"Compass endpoint not set in configuration")
		{
		}
	}
}
