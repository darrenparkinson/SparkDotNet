using System;
using Newtonsoft.Json;

namespace SparkDotNet {
    public class HybridConnectorAlarm
    {
        /// <summary>
        /// A unique identifier for the alarm.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The date and time the alarm was raised.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The severity level of the alarm.
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// The title of the alarm.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A description of the alarm.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The ID of the connector the alarm is raised on.
        /// </summary>
        public string HybridConnectorId { get; set; }
        
        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}