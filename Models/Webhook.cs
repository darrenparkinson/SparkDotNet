using System;
using Newtonsoft.Json;

namespace SparkDotNet {

    /// <summary>
    /// Webhooks allow your app to be notified via HTTP when a specific event occurs in Webex Teams. For example,
    /// your app can register a webhook to be notified when a new message is posted into a specific room.
    /// Events trigger in near real-time allowing your app and backend IT systems to stay in sync with new content and room activity.
    /// Check the Webhooks Guide and our blog regularly for announcements of additional webhook resources and event types.
    /// </summary>
    public class Webhook
    {
        /// <summary>
        /// A unique identifier for the webhook.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// A user-friendly name for the webhook.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// The URL that receives POST requests for each event.
        /// </summary>
        public string targetUrl { get; set; }

        /// <summary>
        /// The resource type for the webhook. Creating a webhook requires 'read' scope on the resource the webhook is for.
        /// memberships: the Memberships resource
        /// messages: the Messages resource
        /// rooms: the Rooms resource
        /// </summary>
        public string resource { get; set; }

        /// <summary>
        /// The event type for the webhook.
        /// created: an object was created
        /// updated: an object was updated
        /// deleted: an object was deleted
        /// </summary>
        [JsonProperty("event")]
        public string sparkevent { get; set; }

        /// <summary>
        /// The filter that defines the webhook scope.
        /// </summary>
        public string filter { get; set; }

        /// <summary>
        /// The secret used to generate payload signature.
        /// </summary>
        public string secret { get; set; }
        
        /// <summary>
        /// The status of the webhook. Use active to reactivate a disabled webhook.
        /// active: the webhook is active
        /// inactive: the webhook is inactive
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// The date and time the webhook was created.
        /// </summary>
        public DateTime created { get; set; }

        public string orgId { get; set; }
        public string createdBy { get; set; }
        public string appId { get; set; }
        public string ownedBy { get; set; }


        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}