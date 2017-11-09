using System;

namespace Compass.Net.Client
{
    public class ConfigOptions
    {
        public Uri CompassUri { get; }

        public int HeartbeatInterval { get; set; } = 15000;

        public ConfigOptions(Uri compassUri)
        {
            CompassUri = compassUri;
        }
    }
}
