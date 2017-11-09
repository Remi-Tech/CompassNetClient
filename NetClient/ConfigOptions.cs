namespace Compass.Net.Client
{
    public class ConfigOptions
    {
        public string CompassUrl { get; }

        public int HeartbeatInterval { get; set; } = 15000;

        public int SubscriptionInterval { get; set; } = 30000;

        public ConfigOptions(string compassUrl)
        {
            CompassUrl = compassUrl;
        }
    }
}
