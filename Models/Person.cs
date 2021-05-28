using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    /// <summary>
    /// People are registered users of Webex Teams.
    /// Searching and viewing People requires an auth token with a scope of spark:people_read.
    /// Viewing the list of all People in your Organization requires an administrator auth token with spark-admin:people_read scope.
    /// Adding, updating, and removing People requires an administrator auth token with the spark-admin:people_write scope.
    /// 
    /// To learn more about managing people in a room see the Memberships API.
    /// For information about how to allocate Hybrid Services licenses to people, see the Managing Hybrid Services guide.
    /// </summary>
    public class Person : WebexObject
    {
        /// <summary>
        /// A unique identifier for the person.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The email addresses of the person.
        /// </summary>
        public string[] emails { get; set; }

        /// <summary>
        /// Phone numbers for the person.
        /// </summary>
        [JsonProperty("phoneNumbers")]
        public PhoneNumber[] PhoneNumbers { get; set; }

        /// <summary>
        /// Sip addresses for the person.
        /// </summary>
        [JsonProperty("sipAddresses")]
        public SipAddress[] SipAddresses { get; set; }

        /// <summary>
        /// The extension of the person retrieved from BroadCloud.
        /// </summary>
        [JsonProperty("extension")]
        public string Extension { get; set; }

        /// <summary>
        /// The ID of the location for this person retrieved from BroadCloud.
        /// </summary>
        [JsonProperty("locationId")]
        public string LocationId { get; set; }

        /// <summary>
        /// The full name of the person.
        /// </summary>
        public string displayName { get; set; }

        /// <summary>
        /// The nickname of the person if configured. If no nickname is configured for the person, this field will not be present.
        /// </summary>
        public string nickName { get; set; }

        /// <summary>
        /// The first name of the person.
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// The last name of the person.
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// The URL to the person's avatar in PNG format.
        /// </summary>
        public string avatar { get; set; }

        /// <summary>
        /// The ID of the organization to which this person belongs.
        /// </summary>
        public string orgId { get; set; }

        /// <summary>
        /// An array of role strings representing the roles to which this person belongs.
        /// </summary>
        public string[] roles { get; set; }

        /// <summary>
        /// An array of license strings allocated to this person.
        /// </summary>
        public string[] licenses { get; set; }

        /// <summary>
        /// The date and time the person was created.
        /// </summary>
        public DateTime created { get; set; }

        /// <summary>
        /// The date and time the person was last changed.
        /// </summary>
        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// The time zone of the person if configured. If no timezone is configured on the account, this field will not be present
        /// </summary>
        public string timeZone { get; set; }

        /// <summary>
        /// The date and time of the person's last activity within Webex Teams.
        /// </summary>
        public DateTime lastActivity { get; set; }

        /// <summary>
        /// The current presence status of the person.
        /// active: active within the last 10 minutes
        /// call: the user is in a call
        /// DoNotDisturb: the user has manually set their status to "Do Not Disturb"
        /// inactive: last activity occurred more than 10 minutes ago
        /// meeting: the user is in a meeting
        /// OutOfOffice: the user or a Hybrid Calendar service has indicated that they are "Out of Office"
        /// pending: the user has never logged in; a status cannot be determined
        /// presenting: the user is sharing content
        /// unknown: the user’s status could not be determined
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// Whether or not an invite is pending for the user to complete account activation.
        /// This property is only returned if the authenticated user is an admin user for the person's organization.
        /// true: the person has been invited to Webex Teams but has not created an account
        /// false: an invite is not pending for this person
        /// </summary>
        [JsonProperty("invitePending")]
        public bool InvitePending { get; set; }

        /// <summary>
        /// Whether or not the user is allowed to use Webex Teams.
        /// This property is only returned if the authenticated user is an admin user for the person's organization.
        /// true: the person can log into Webex Teams
        /// false: the person cannot log into Webex Teams
        /// </summary>
        [JsonProperty("loginEndbaled")]
        public bool LoginEnabled { get; set; }

        /// <summary>
        /// The type of person account, such as person or bot.
        /// person: account belongs to a person
        /// bot: account is a bot user
        /// appuser: account is a guest user
        /// </summary>
        public string type { get; set; }
    }
}