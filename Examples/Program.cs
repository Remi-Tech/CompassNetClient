using Compass.Net.Client;
using Compass.Net.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var subscription = new ServiceSubscription
            {
                ApplicationToken = new Guid("e6e749e1-ced6-485d-b359-c58900f5becf"),
                ApplicationUri = new Uri("http://loadbalancer:8080/"),
                SubscribedEvents = new List<string> { "AddAccount" }
            };
            var compass = new Client(new ConfigOptions(new Uri("http://localhost:5000/")));
            var task = compass.SubscribeAsync(subscription).Result;

            Thread.Sleep(900000);
        }
    }
}
