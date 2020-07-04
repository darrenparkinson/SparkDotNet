using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class AdminEventData
    {
        public string ActorOrgName { get; set; }
        public string TargetName { get; set; }
        public string EventDescription { get; set; }
        public string ActorName { get; set; }
        public string[] AdminRoles { get; set; }
        public string TrackingId { get; set; }
        public string TargetType { get; set; }
        public string TargetId { get; set; }
        public string EventCategory { get; set; }
        public string ActorUserAgent { get; set; }
        public string ActorIp { get; set; }
        public string TargetOrgId { get; set; }
        public string ActionText { get; set; }
        public string TargetOrgName { get; set; }

        public override string ToString()
        { 
            return JsonConvert.SerializeObject(this);
        }
    }
}