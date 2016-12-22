using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Team
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime created { get; set; }
        public string creatorId { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}