using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Webhook
    {
        public string id { get; set; }
        public string name { get; set; }
        public string targetUrl { get; set; }
        public string resource { get; set; }
        
        [JsonProperty("event")]
        public string sparkevent { get; set; }
        public string orgId { get; set; }
        public string createdBy { get; set; }
        public string appId { get; set; }
        public string ownedBy { get; set; }
        public string status { get; set; }
        public string filter { get; set; }
        public string secret { get; set; }
        public DateTime created { get; set; }

       public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}