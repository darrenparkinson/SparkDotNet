using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Role
    {
        public string id { get; set; }
        public string name { get; set; }
        
        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}