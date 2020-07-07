namespace SparkDotNet {

    public class CallParkedAgainst : WebexObject
    {        
        /// <summary>
        /// Name of the Person where is call is parked against
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Identified where the call is parked 
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Id of the person where the call is parked
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Id of the place where the call is parked.
        /// </summary>
        public string PlaceId { get; set; }

        /// <summary>
        /// Indicates whether privacy is enabled for the name and number.
        /// </summary>
        public bool PrivacyEnabled { get; set; }
        
        public string CallType { get; set; }
    }
}