using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Call
    {
        public string Id { get; set; }
        public string CallSessionId { get; set; }
        public string Personality { get; set; }
        public string State { get; set; }
        public object RemoteParty { get; set; }
        public string Appearance { get; set; }
        public DateTime Created { get; set; }
        public DateTime Answered { get; set; }
        public object[] Redirections { get; set; }
        public string Reason { get; set; }
        public string RedirectingParty { get; set; }
        public string Recall { get; set; }
        public string RecordingState { get; set; }



        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}