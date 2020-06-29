using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class Place
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string OrgId { get; set; }
        public string SipAddress { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}