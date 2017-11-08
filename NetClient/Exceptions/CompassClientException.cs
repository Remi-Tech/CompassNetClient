using System;
namespace Compass.Net.Client.Exceptions
{
    public class CompassClientException : Exception
    {
        public CompassClientException(string message) : base(message) { }

        public CompassClientException(string message, Exception inner)
            : base($"There was an error connecting to compass : {message}.", inner)
        {
        }
    }
}
