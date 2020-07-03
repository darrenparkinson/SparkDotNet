using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class Organization
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public DateTime created { get; set; }

        #region XSI Properties
        public string XsiActionsEndpoint  { get; set; }
        public string XsiEventsEndpoint { get; set; }
        public string XsiEventsChannelEndpoint { get; set; }
        public string XsiDomain { get; set; }
        #endregion XSI Properties


        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}