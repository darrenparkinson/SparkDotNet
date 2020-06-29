using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class SipAddress
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Primary { get; set; }
        
       public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}