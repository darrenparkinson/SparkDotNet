using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class HybridConnectorAlarm
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string Severity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string HybridConnectorId { get; set; }
        
        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}