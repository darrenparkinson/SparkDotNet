using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class Room
    {
        public string id { get; set; }
        public string title { get; set; }
        public string teamId { get; set; }
        public bool isLocked { get; set; }
        public DateTime created { get; set; }
        public DateTime lastActivity { get; set; }
        public string type { get; set; }
        public string creatorId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}