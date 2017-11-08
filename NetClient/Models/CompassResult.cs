using System.Collections.Generic;

namespace Compass.Net.Client.Models
{
    public class CompassResult
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public List<dynamic> Response { get; set; } = new List<dynamic>();
    }
}