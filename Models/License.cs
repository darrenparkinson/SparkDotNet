using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class License
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string totalUnits { get; set; }
        public string consumedUnits { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}