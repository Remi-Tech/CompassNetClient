using System;
using Compass.Net.Client.Models;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: InternalsVisibleTo("CompassTests")]

namespace Compass.Net.Client.Config
{
    internal class CompassHeartbeat : IDisposable
    {
        private readonly ConfigOptions _options;
        private Timer _timer;

        public CompassHeartbeat(ConfigOptions options)
        {
            _options = options;
        }

        public void SendBeatAsync(ServiceSubscription sub)
        {
            // create a timer that will run every x seconds
            GenerateTimer(sub);
        }

        private void GenerateTimer(ServiceSubscription sub)
        {
            var interval = TimeSpan.FromMilliseconds(_options.HeartbeatInterval);
            _timer = new Timer(async state => await RunHeartbeatAsync((ServiceSubscription)state), sub, interval,
                interval);
        }

        private async Task RunHeartbeatAsync(ServiceSubscription sub)
        {
            await Shared.CompassRestClient.SendRequestAsync<ServiceSubscription>(new Uri(_options.CompassUrl + "/heartbeat"), sub);
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}