using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class TeamMembership
    {
        public string id { get; set; }
        public string teamId { get; set; }
        public string personId { get; set; }
        public string personEmail { get; set; }
        public bool isModerator { get; set; }
        public DateTime created { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}