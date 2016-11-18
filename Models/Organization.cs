using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Organization
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public DateTime created { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}