using System;
using System.Threading.Tasks;
using Compass.Net.Client.Models;
using Compass.Net.Client.Exceptions;
using Compass.Net.Client.Shared;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CompassTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Compass.Net.Client.Config
{
    internal class CompassSubscribe
    {
        private readonly ConfigOptions _options;

        public CompassSubscribe(ConfigOptions options)
        {
            _options = options;
        }

        public async Task<ServiceSubscription> ClientSubscribe(ServiceSubscription serviceSubscription)
        {
            // if no compass url is set, then we exit.
            if (_options.CompassUrl == null)
            {
                throw new NoCompassEndpointSetException();
            }

            var response =
            await CompassRestClient.SendRequestAsync<ServiceSubscription>(
                new Uri(_options.CompassUrl + "/subscribe"), serviceSubscription);

            // default timer of 15 seconds
            var heartbeat = new CompassHeartbeat(_options);
            heartbeat.SendBeatAsync(response);

            return response;

        }
    }
}