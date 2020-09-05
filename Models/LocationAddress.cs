using System;

namespace SparkDotNet {

    public class LocationAddress : WebexObject
    {
        /// <summary>
        /// Address line 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address line 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// ZIP/Postal Code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
    }
}