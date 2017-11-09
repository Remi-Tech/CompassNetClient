using System.Threading.Tasks;
using Compass.Net.Client.Models;
using Compass.Net.Client.Shared;
using Compass.Net.Client.Exceptions;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CompassTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Compass.Net.Client
{
    internal class CompassRequest
    {
        private readonly ConfigOptions _options;

        public CompassRequest(ConfigOptions options)
        {
            _options = options;
        }

        public async Task<CompassResult> SendRequestAsync(CompassEvent compassEvent)
        {
            // if no compass url is set, then we bail
            if (_options.CompassUri == null)
            {
                throw new NoCompassEndpointSetException(compassEvent.EventName);
            }

            // build the request and send
            return await CompassRestClient.SendRequestAsync<CompassResult>(_options.CompassUri, compassEvent);
        }
    }
}