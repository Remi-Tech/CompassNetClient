using Xunit;
using System.Threading.Tasks;
using FakeItEasy;
using Compass.Net.Client.Exceptions;
using Compass.Net.Client;
using Compass.Net.Client.Models;

namespace CompassTests
{
	// Note: tests are light - client uses primarily delegates for RestSharp which are not testable
	public class CompassRequestTests
    {
        [Fact(Skip = "RestSharp not working")]
        public async Task TestCompassRequestOptionFailAsync()
        {
            var request = A.Fake<CompassRequest>(
                options => options.WithArgumentsForConstructor(new object[] { A.Fake<ConfigOptions>() }));

			await Assert.ThrowsAsync<NoCompassEndpointSetException>(async () =>
                        await request.SendRequestAsync(new CompassEvent()));
        }
    }
}