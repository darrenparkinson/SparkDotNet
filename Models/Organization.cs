using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Organization
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public DateTime created { get; set; }

        #region XSI Properties
        [JsonProperty(PropertyName = "xsiActionsEndpoint")]
        public string XsiActionsEndpoint  { get; set; }
        [JsonProperty(PropertyName = "xsiEventsEndpoint")]
        public string XsiEventsEndpoint { get; set; }
        [JsonProperty(PropertyName = "xsiEventsChannelEndpoint")]
        public string XsiEventsChannelEndpoint { get; set; }
        [JsonProperty(PropertyName = "xsiDomain")]
        public string XsiDomain { get; set; }
        #endregion XSI Properties


        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}