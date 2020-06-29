using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class Device
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string PlaceId { get; set; }
        public string PersonId { get; set; }
        public string OrgId { get; set; }
        public string[] Capabilities { get; set; }
        public string[] Permissions { get; set; }
        public string ConnectionStatus { get; set; }
        public string Product { get; set; }
        public string[] Tags { get; set; }
        public string Ip { get; set; }
        public string ActiveInterface { get; set; }
        public string Mac { get; set; }
        public string PrimarySipUrl { get; set; }
        public string[] SipUrls { get; set; }
        public string Serial { get; set; }
        public string Software { get; set; }
        public string UpgradeChannel { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}