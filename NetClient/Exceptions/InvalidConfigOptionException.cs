using System;

namespace Compass.Net.Client.Exceptions
{
    public class InvalidConfigOptionException : Exception
    {
		public InvalidConfigOptionException(string optionValue)
            : base($"Invalid value for option : {optionValue}.")
        {
		}
    }
}
