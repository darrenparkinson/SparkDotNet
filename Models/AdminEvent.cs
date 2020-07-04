using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    public class AdminEvent
    {
        public AdminEventData Data { get; set; }
        public DateTime Created { get; set; }
        public string ActorOrgId { get; set; }
        public string Id { get; set; }
        public string ActorId { get; set; }

        public override string ToString()
        { 
            return JsonConvert.SerializeObject(this);
        }
    }
}