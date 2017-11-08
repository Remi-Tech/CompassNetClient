using System;

namespace Compass.Net.Client.Models
{
    public class CompassEvent
    {
        public string EventName { get; set; }
        public Guid ApplicationToken { get; set; }
        public object Payload { get; set; }
        public string UserId { get; set; }
    }
}