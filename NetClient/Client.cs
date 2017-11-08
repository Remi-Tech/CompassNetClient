using Compass.Net.Client.Models;
using Compass.Net.Client.Config;
using System.Threading.Tasks;

namespace Compass.Net.Client
{
    public class Client
    {
        private readonly ConfigOptions _options;
        private readonly CompassSubscribe _compassSubscribe;
        private readonly CompassRequest _compassRequest;

        // Constructor for client that requires options to be set
        public Client(ConfigOptions options)
        {
            _options = options;
            _compassSubscribe = new CompassSubscribe(options);
            _compassRequest = new CompassRequest(options);
        }

        public ConfigOptions GetOptions()
        {
            return _options;
        }

        // Initially subscribe to new service - also calls heartbeat endpoint
        public async Task<ServiceSubscription> SubscribeAsync(ServiceSubscription subscription)
        {
            return await _compassSubscribe.ClientSubscribe(subscription);
        }

        // send standard event through compass
        public async Task<CompassResult> SendRequestAsync(CompassEvent compassEvent)
        {
            return await _compassRequest.SendRequestAsync(compassEvent);
        }
    }
}
