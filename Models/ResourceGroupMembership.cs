using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class ResourceGroupMembership
    {
        public string Id { get; set; }
        public string ResourceGroupId { get; set; }
        public string LicenseId { get; set; }
        public string PersonId { get; set; }
        public string PersonOrgId { get; set; }
        public string Status { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}