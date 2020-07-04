using System;
using Newtonsoft.Json;

namespace SparkDotNet
{

    /// <summary>
    /// Query the current status of the Webex RoomOS Device.
    /// Specify the target device in the deviceId parameter in the URI.
    /// The target device is queried for statuses according to the expression in the name parameter.
    /// See the xAPI Guide for a description of status expressions.
    /// </summary>
    public class XAPIStatus
    {
        /// <summary>
        /// The unique identifier for the Webex RoomOS Device.
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// xAPI status result
        /// </summary>
        public XAPIStatusResult result { get; set; }

        public override string ToString()
        { 
            return JsonConvert.SerializeObject(this);
        }
    }
}