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
                ApplicationToken = new Guid("6a964f1a-b17b-4998-b415-10d7eaea2d7c"),
                ApplicationUri = new Uri("http://loadbalancer:4000/"),
                SubscribedEvents = new List<string> { "AddAccount" }
            };
            var compass = new Client(new ConfigOptions("http://localhost:5000"));
            var task = compass.SubscribeAsync(subscription).Result;

            Thread.Sleep(900000);
        }
    }
}
