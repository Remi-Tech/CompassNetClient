using System;
using System.Collections.Generic;

namespace Compass.Net.Client.Models
{
    public class ServiceSubscription
    {
        public Guid Identifier { get; set; }
        public Guid ApplicationToken { get; set; }
        public Uri ApplicationUri { get; set; }
        public ICollection<string> SubscribedEvents { get; set; } = new List<string>();
    }
}