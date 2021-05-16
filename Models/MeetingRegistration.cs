using Newtonsoft.Json;

namespace SparkDotNet {

    public class MeetingRegistration : WebexObject
    {
        /// <summary>
        /// Whether or not meeting registration request is accepted automatically.
        /// </summary>
        [JsonProperty("autoAcceptRequest")]
        public bool AutoAcceptRequest { get; set; }

        /// <summary>
        /// Whether or not registrant's first name is required for meeting registration.
        /// </summary>
        [JsonProperty("requireFirstName")]
        public bool RequireFirstName { get; set; }

        /// <summary>
        /// Whether or not registrant's last name is required for meeting registration.
        /// </summary>
        [JsonProperty("requireLastName")]
        public bool RequireLastName { get; set; }

        /// <summary>
        /// Whether or not registrant's email is required for meeting registration.
        /// </summary>
        [JsonProperty("requireEmail")]
        public bool RequireEmail { get; set; }

        /// <summary>
        /// Whether or not registrant's job title is required for meeting registration.
        /// </summary>
        [JsonProperty("requireJobTitle")]
        public bool RequireJobTitle { get; set; }

        /// <summary>
        /// Whether or not registrant's company name is required for meeting registration.
        /// </summary>
        [JsonProperty("requireCompanyName")]
        public bool RequireCompanyName { get; set; }

        /// <summary>
        /// Whether or not registrant's 1st address is required for meeting registration.
        /// </summary>
        [JsonProperty("requireAddress1")]
        public bool RequireAddress1 { get; set; }

        /// <summary>
        /// Whether or not registrant's 2nd address is required for meeting registration.
        /// </summary>
        [JsonProperty("requireAddress2")]
        public bool RequireAddress2 { get; set; }

        /// <summary>
        /// Whether or not registrant's city is required for meeting registration.
        /// </summary>
        [JsonProperty("requireCity")]
        public bool RequireCity { get; set; }

        /// <summary>
        /// Whether or not registrant's state is required for meeting registration.
        /// </summary>
        [JsonProperty("requireState")]
        public bool RequireState { get; set; }

        /// <summary>
        /// Whether or not registrant's zip code is required for meeting registration.
        /// </summary>
        [JsonProperty("requireZipCode")]
        public bool RequireZipCode { get; set; }

        /// <summary>
        /// Whether or not registrant's country or region is required for meeting registration.
        /// </summary>
        [JsonProperty("requireCountryRegion")]
        public bool RequireCountryRegion { get; set; }

        /// <summary>
        /// Whether or not registrant's work phone number is required for meeting registration.
        /// </summary>
        [JsonProperty("requireWorkPhone")]
        public bool RequireWorkPhone { get; set; }

        /// <summary>
        /// Whether or not registrant's fax number is required for meeting registration.
        /// </summary>
        [JsonProperty("requireFax")]
        public bool RequireFax { get; set; }
    }
}