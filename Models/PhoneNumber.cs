using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class PhoneNumber
    {
        public string Type { get; set; }
        public string Value { get; set; }
        
       public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}