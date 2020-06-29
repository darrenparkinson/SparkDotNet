using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class ResourceGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OrgId { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}