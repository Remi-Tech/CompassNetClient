﻿using Compass.Net.Client;
using Xunit;
namespace CompassTests
{
    // Note: tests are light - client uses primarily delegates for RestSharp which are not testable
	public class CompassClientTests
	{
		[Fact]
		public void TestClientOptions()
		{
            var options = new ConfigOptions("http://google.com")
            {
                HeartbeatInterval = 15000,
                
            };
            var Client = new Client(options);
            Assert.True(Client.GetOptions().CompassUrl == "http://google.com");
            Assert.True(Client.GetOptions().HeartbeatInterval == 15000);
		}
	}
}