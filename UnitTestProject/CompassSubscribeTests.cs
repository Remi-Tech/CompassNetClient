using Xunit;
using FakeItEasy;
using System.Threading.Tasks;
using Compass.Net.Client.Exceptions;
using Compass.Net.Client.Config;
using Compass.Net.Client.Models;
using Compass.Net.Client;

namespace CompassTests
{
	// Note: tests are light - client uses primarily delegates for RestSharp which are not testable
	public class CompassSubscribeTests
	{
        [Fact(Skip = "RestSharp not working")]
		public async Task TestCompassSubscribeFailAsync()
		{
			var request = A.Fake<CompassSubscribe>(
	            options => options.WithArgumentsForConstructor(new object[] { A.Fake<ConfigOptions>() }));

			await Assert.ThrowsAsync<NoCompassEndpointSetException>(async () =>
					await request.ClientSubscribe(new ServiceSubscription()));
		}
	}
}