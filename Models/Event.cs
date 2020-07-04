using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Event
    {
        public string Id { get; set; }
        public string Resource { get; set; }
        public string Type { get; set; }
        public string AppId { get; set; }
        public string ActorId { get; set; }
        public DateTime Created { get; set; }
        public EventData[] Data { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}