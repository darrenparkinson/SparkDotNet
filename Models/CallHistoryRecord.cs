using System;

namespace SparkDotNet {
    public class CallHistoryRecord : WebexObject
    {
        /// <summary>
        /// The type of call history record.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The name of the called/calling party. Only present when the name is available and privacy is not enabled.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of the called/calling party. Only present when the number is available and privacy is not enabled.
        /// The number can be digits or a URI. Some examples for number include: 1234, 2223334444, +12223334444, *73, user@company.domain
        /// </summary>
        public string number { get; set; }

        /// <summary>
        /// Indicates whether privacy is enabled for the name and number.
        /// </summary>
        public bool PrivacyEnabled { get; set; }

        /// <summary>
        /// The date and time the call history record was created.
        /// For a placed call history record, this is when the call was placed. For a missed call history record, this is when the call was disconnected.
        /// For a received call history record, this is when the call was answered.
        /// </summary>
        public DateTime time { get; set; }
    }
}