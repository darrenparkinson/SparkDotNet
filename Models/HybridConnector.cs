using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class HybridConnector
    {
        public string Id { get; set; }
        public string OrgId { get; set; }
        public string HybridClusterId { get; set; }
        public string Hostname { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public HybridConnectorAlarm[] Alarms { get; set; };

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}