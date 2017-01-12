using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Links
    {
        public string Next { get; set; }
        public string Prev { get; set; }
        public string First { get; set; }
        
       public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}